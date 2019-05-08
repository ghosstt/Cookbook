using Entities = Cookbook.Api.Data.Entities;
using Enum = Cookbook.Api.Features.Security.Enums;
using System;
using System.Collections.Generic;

namespace Cookbook.Api.Features.User.Dto
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        //public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Guid LastUpdatedBy { get; set; }
        //public DateTime LastUpdatedDate { get; set; }
        //public byte[] OptimisticLockField { get; set; }

        public List<Enum.Role> Roles { get; set; }
        public List<Enum.Permission> Permissions { get; set; }

        public List<Entities.Recipe> Recipes { get; set; }
        public List<Entities.Ingredient> Ingredients { get; set; }
    }
}
