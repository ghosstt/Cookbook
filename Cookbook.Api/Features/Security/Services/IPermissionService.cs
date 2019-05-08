using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Security.Services
{
    public interface IPermissionService
    {
        Task<int> AddUserPermission(int userId, int permissionId);
        Task<int> AddUserPermissionRange(int userId, IEnumerable<int> permissionIds);
        Task<int> AddRolePermission(int roleId, int permissionId);
        Task<int> AddRolePermissionRange(int roleId, IEnumerable<int> permissionIds);
    }
}
