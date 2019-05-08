using System;
using System.Collections.Generic;

namespace Cookbook.Api.Data.Entities
{
    public class UserPermission
    {
        public int UserPermissionId { get; set; }
        //public int UserId { get; set; }
        public Guid UserId { get; set; }
        public int PermissionId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
