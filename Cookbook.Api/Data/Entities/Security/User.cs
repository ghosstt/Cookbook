using System;
using System.Collections.Generic;

namespace Cookbook.Api.Data.Entities
{
    public class User
    {
        // public int UserId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        //public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Guid LastUpdatedBy { get; set; }
        //public DateTime LastUpdatedDate { get; set; }
        //public byte[] OptimisticLockField { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
