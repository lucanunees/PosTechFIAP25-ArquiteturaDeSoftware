using FiapCloudGames.Domain.Request;
using FiapCloudGames.Domain.Response;

namespace FiapCloudGames.Application.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<IList<PromotionResponse>> GetAllAsync();
        Task<PromotionResponse?> GetByIdAsync(int id);
        Task<PromotionResponse> CreateAsync(PromotionRequest request);
        Task<PromotionResponse?> UpdateAsync(int id, PromotionRequest request);
        Task<bool> DeleteAsync(int id);

        Task<bool> IsTitleUniqueAsync(string title, int? ignoreId = null);
        bool AreDatesValid(DateTime start, DateTime end);
        Task<bool> HasOverlappingAsync(DateTime start, DateTime end, int? ignoreId = null);
    }
}