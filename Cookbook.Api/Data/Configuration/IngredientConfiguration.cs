using Cookbook.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.Api.Data.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(c => c.IngredientId);
            // builder.HasKey(c => new { c.User.UserId, c.IngredientId });

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.ImgSrc)
                .IsRequired()
                .HasColumnType("varchar(128)");
        }
    }
}
