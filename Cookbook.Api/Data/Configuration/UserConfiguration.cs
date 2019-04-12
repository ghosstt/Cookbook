using Cookbook.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookbook.Api.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.UserId);
            builder.HasAlternateKey(c => c.UserName);

            builder.Property(c => c.UserName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.PasswordHash)
                .IsRequired()
                .HasColumnType("varbinary(130)");

            builder.Property(c => c.PasswordSalt)
                .IsRequired()
                .HasColumnType("varbinary(258)");

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("varchar(50)");
        }
    }
}
