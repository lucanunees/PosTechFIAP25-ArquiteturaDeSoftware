using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Entity;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Domain.Request;
using FiapCloudGames.Domain.Response;

namespace FiapCloudGames.Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repo;

        public PromotionService(IPromotionRepository repo)
        {
            _repo = repo;
        }

        public Task<IList<PromotionResponse>> GetAllAsync()
        {
            var items = _repo.GetAll()
                .Select(MapToResponse)
                .ToList();
            return Task.FromResult<IList<PromotionResponse>>(items);
        }

        public Task<PromotionResponse?> GetByIdAsync(int id)
        {
            var entity = _repo.GetById(id);
            return Task.FromResult(entity is null ? null : MapToResponse(entity));
        }

        public async Task<PromotionResponse> CreateAsync(PromotionRequest request)
        {
            ValidateBasic(request);

            if (!await IsTitleUniqueAsync(request.Title))
                throw new ArgumentException("Title must be unique.");

            if (await HasOverlappingAsync(request.StartDate, request.EndDate))
                throw new ArgumentException("Promotion dates overlap with an existing promotion.");

            var entity = new Promotion
            {
                Title = request.Title.Trim(),
                Description = request.Description,
                DiscountPercentage = request.DiscountPercentage,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _repo.Create(entity);

            return MapToResponse(entity);
        }

        public async Task<PromotionResponse?> UpdateAsync(int id, PromotionRequest request)
        {
            var existing = _repo.GetById(id);
            if (existing is null) return null;

            ValidateBasic(request);

            if (!await IsTitleUniqueAsync(request.Title, ignoreId: id))
                throw new ArgumentException("Title must be unique.");

            if (await HasOverlappingAsync(request.StartDate, request.EndDate, ignoreId: id))
                throw new ArgumentException("Promotion dates overlap with an existing promotion.");

            existing.Title = request.Title.Trim();
            existing.Description = request.Description;
            existing.DiscountPercentage = request.DiscountPercentage;
            existing.StartDate = request.StartDate;
            existing.EndDate = request.EndDate;
            existing.IsActive = request.IsActive;
            existing.UpdatedAt = DateTime.UtcNow;

            _repo.Update(existing);

            return MapToResponse(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var existing = _repo.GetById(id);
            if (existing is null) return Task.FromResult(false);

            _repo.Delete(id);
            return Task.FromResult(true);
        }

        public Task<bool> IsTitleUniqueAsync(string title, int? ignoreId = null)
        {
            var normalized = (title ?? string.Empty).Trim();
            var exists = _repo.GetAll()
                .Any(p => p.Title.Equals(normalized, StringComparison.OrdinalIgnoreCase)
                          && (!ignoreId.HasValue || p.Id != ignoreId.Value));
            return Task.FromResult(!exists);
        }

        public bool AreDatesValid(DateTime start, DateTime end) => start <= end;

        public Task<bool> HasOverlappingAsync(DateTime start, DateTime end, int? ignoreId = null)
        {
            // Overlap rule: [a,b] overlaps [c,d] if a <= d && c <= b
            var overlaps = _repo.GetAll()
                .Any(p =>
                    (!ignoreId.HasValue || p.Id != ignoreId.Value) &&
                    p.IsActive &&
                    p.StartDate <= end &&
                    start <= p.EndDate);

            return Task.FromResult(overlaps);
        }

        private void ValidateBasic(PromotionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                throw new ArgumentException("Title is required.");

            if (!AreDatesValid(request.StartDate, request.EndDate))
                throw new ArgumentException("StartDate must be less than or equal to EndDate.");

            if (request.DiscountPercentage < 0 || request.DiscountPercentage > 100)
                throw new ArgumentException("DiscountPercentage must be between 0 and 100.");
        }

        private static PromotionResponse MapToResponse(Promotion p) => new PromotionResponse
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            DiscountPercentage = p.DiscountPercentage,
            StartDate = p.StartDate,
            EndDate = p.EndDate,
            IsActive = p.IsActive,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        };
    }
}