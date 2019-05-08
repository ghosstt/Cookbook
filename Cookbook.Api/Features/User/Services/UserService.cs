using Cookbook.Api.Data;
using Cookbook.Api.Features.User.Dto;
using Cookbook.Api.Helpers;
using Enum = Cookbook.Api.Features.Security.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Api.Data.Entities;

namespace Cookbook.Api.Features.User.Services
{
    public class UserService : IUserService
    {
        private readonly CookbookDbContext _context;

        public UserService(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddUser(UserDto userDto)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == userDto.UserName))
                throw new Exception("Username already exists");

            var user = new Data.Entities.User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.UserName.ToLower(),
                EmailAddress = userDto.EmailAddress,
                CreatedDate = DateTime.UtcNow
            };

            AuthHelper.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.UserId;
        }

        public async Task<UserDto> GetUserById(Guid userId)
        {
            return null;
        }

        public async Task<UserDto> GetUserByUserName(string userName)
        {
            return null;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return null;
        }

        public async Task<Guid> RemoveUser(UserDto userDto)
        {
            return Guid.Empty;
        }

        public async Task<Guid> UpdateUser(UserDto userDto)
        {
            return Guid.Empty;
        }

        public async Task<Guid> CreateDefaultAdminUser()
        {
            if (!await _context.Users.AnyAsync(u => u.UserName == "admin"))
            {
                var user = new UserDto()
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Password = "admin",
                    EmailAddress = "admin@cookbook.com",
                    Roles = new List<Enum.Role>()
                    {
                        Enum.Role.Admin
                    }
                };

                Guid userId = await AddUser(user);
                await AddUserRole(userId, user.Roles);

                return userId;
            }

            return Guid.Empty;
        }

        public async Task<int> AddUserRole(Guid userId, IEnumerable<Enum.Role> roles)
        {
            if (userId == Guid.Empty || roles == null || roles.Count() == 0)
                return 0;

            if (await _context.UserRoles.AnyAsync(ur => ur.UserId == userId && roles.Contains((Enum.Role)ur.RoleId)))
                return 0;

            // add user role
            var userRoleList = new List<UserRole>();
            userRoleList.AddRange(roles.Select(roleId => new UserRole
            {
                UserId = userId,
                RoleId = (int)roleId
            }));

            await _context.UserRoles.AddRangeAsync(userRoleList);

            // add permission based on role


            return await _context.SaveChangesAsync();
        }
    }
}
