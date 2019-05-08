using System;
using System.Collections.Generic;

namespace Cookbook.Api.Data.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        // public int UserId { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
