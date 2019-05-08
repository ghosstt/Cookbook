using Cookbook.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Api.Data
{
    public class CookbookDbContext : DbContext
    {
        public CookbookDbContext(DbContextOptions<CookbookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(name: "Users", schema: "Security");
            modelBuilder.Entity<UserPermission>().ToTable(name: "UserPermissions", schema: "Security");
            modelBuilder.Entity<Permission>().ToTable(name: "Permissions", schema: "Security");
            modelBuilder.Entity<PermissionGroup>().ToTable(name: "PermissionGroups", schema: "Security");
            modelBuilder.Entity<UserRole>().ToTable(name: "UserRoles", schema: "Security");
            modelBuilder.Entity<Role>().ToTable(name: "Roles", schema: "Security");
            modelBuilder.Entity<RolePermission>().ToTable(name: "RolePermissions", schema: "Security");

            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            //modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        }

        // dbo
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        // Security
        public DbSet<User> Users { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
    }
}
