using FiapCloudGames.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloudGames.Infrastructure.Repository.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotion");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(c => c.Title).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("VARCHAR(1000)").IsRequired();
            builder.Property(c => c.DiscountPercentage).HasColumnType("DECIMAL(5,2)").IsRequired();
            builder.Property(c => c.StartDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.EndDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.IsActive).HasColumnType("INT").IsRequired();
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnType("DATETIME").IsRequired();
        }
    }
}
