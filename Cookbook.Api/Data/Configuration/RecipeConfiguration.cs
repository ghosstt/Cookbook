using Cookbook.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.Api.Data.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(c => c.RecipeId);
            // builder.HasKey(c => new { c.User.UserId, c.RecipeId });

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.ImgSrc)
                .IsRequired()
                .HasColumnType("varchar(128)");

            builder.Property(c => c.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
