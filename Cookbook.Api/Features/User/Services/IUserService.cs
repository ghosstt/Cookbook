using Enum = Cookbook.Api.Features.Security.Enums;
using Cookbook.Api.Features.User.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.User.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(Guid userId);
        Task<UserDto> GetUserByUserName(string userName);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<Guid> AddUser(UserDto userDto);
        Task<Guid> UpdateUser(UserDto userDto);
        Task<Guid> RemoveUser(UserDto userDto);

        Task<int> AddUserRole(Guid userId, IEnumerable<Enum.Role> roles);

        Task<Guid> CreateDefaultAdminUser();

    }
}
