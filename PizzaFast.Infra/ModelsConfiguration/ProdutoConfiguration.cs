using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaFast.Domain.Models;

namespace PizzaFast.Infra.ModelsConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Nome).HasPrecision(10, 2).IsRequired();

            builder.HasOne(p => p.Categoria).WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
