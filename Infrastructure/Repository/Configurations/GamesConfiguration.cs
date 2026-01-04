using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    //Implmentando essa interface, permite com que eu faça as configurações da entidade Customer, separado da classe ApplicationDbContext.
    public class GamesConfiguration : IEntityTypeConfiguration<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.ToTable("Games"); // Nome da tabela no banco de dados
            builder.HasKey(c => c.Id); // Chave primária
            builder.Property(c => c.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn(); // define o tipo da coluna como INT, utilizando o value generated never para não gerar valor automaticamente (Iddentity).
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired(); // Propriedade obrigatória e do tipo DATETIME.
            builder.Property(c => c.Name).HasColumnType("VARCHAR(100)").IsRequired();  // Propriedade do tipo varchar.
            builder.Property(c => c.Price).HasColumnType("DECIMAL(10, 2)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("VARCHAR(1000)");
            builder.Property(c => c.CategoryId).HasColumnType("INT").IsRequired();
            builder.Property(c => c.ReleaseDate).HasColumnType("DATETIME").IsRequired();

            // Um jogo pertence a uma categoria, e uma categoria pode ter vários jogos.
            builder.HasOne(c => c.Category)
                   .WithMany()
                   .HasForeignKey(c => c.CategoryId);
        }
    }
}
