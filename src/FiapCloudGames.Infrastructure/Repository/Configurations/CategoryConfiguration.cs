using FiapCloudGames.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapCloudGames.Infrastructure.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("VARCHAR(1000)").IsRequired();

        }
    }
}
