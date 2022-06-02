using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaFast.Domain.Models;

namespace PizzaFast.Infra.ModelsConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Categoria(1, "Pizza Grande"),
                new Categoria(2, "Pizza Média"),
                new Categoria(3, "Pizza Pequena"),
                new Categoria(4, "Bebidas")
            );
        }
    }
}
