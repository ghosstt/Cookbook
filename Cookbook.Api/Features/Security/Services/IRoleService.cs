using Cookbook.Api.Features.Security.Dto;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Security.Services
{
    public interface IRoleService
    {
        Task<int> AddRole(RoleDto roleDto);
        Task<int> UpdateRole(RoleDto roleDto);
        Task<int> DeleteRole(int roleId);
    }
}
