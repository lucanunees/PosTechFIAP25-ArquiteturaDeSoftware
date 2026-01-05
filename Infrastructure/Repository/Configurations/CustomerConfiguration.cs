using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations 
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer"); // Nome da tabela no banco de dados
            builder.HasKey(c => c.Id); // Chave primária
            builder.Property(c => c.Id).HasColumnType("INT").UseIdentityColumn(); // define o tipo da coluna como INT, utilizando o value generated never para não gerar valor automaticamente (Iddentity).
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired(); // Propriedade obrigatória e do tipo DATETIME.
            builder.Property(c => c.Name).HasColumnType("VARCHAR(100)"); // Propriedade do tipo varchar.
            builder.Property(c => c.BirthDate).HasColumnType("DATETIME").IsRequired(); // propriedade do tipo DATETIME e obrigatória.
            builder.Property(c => c.Email).HasColumnType("VARCHAR(100)").IsRequired(); // propriedade do tipo VARCHAR e obrigatória.
            builder.Property(c => c.Phone).HasColumnType("INT"); // propriedade do tipo INT.
        }
    }
}
