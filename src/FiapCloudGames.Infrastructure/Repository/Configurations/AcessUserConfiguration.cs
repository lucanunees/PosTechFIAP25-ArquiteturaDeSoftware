using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class AcessUserConfiguration : IEntityTypeConfiguration<AcessUser>
    {
        public void Configure(EntityTypeBuilder<AcessUser> builder)
        {
            builder.ToTable("AcessUser");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.Username).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Password).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Role).HasColumnType("VARCHAR(20)").IsRequired();

        }
    }
}
