using Cookbook.Api.Data;
using Entities = Cookbook.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Security.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly CookbookDbContext _context;

        public PermissionService(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserPermission(int userId, int permissionId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddUserPermissionRange(int userId, IEnumerable<int> permissionIds)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddRolePermission(int roleId, int permissionId)
        {
            if (await _context.RolePermissions.AnyAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId))
                throw new Exception($"PermissionId {permissionId} already exist on RoleId {roleId}");

            var rolePermission = new Entities.RolePermission()
            {
                RoleId = roleId,
                PermissionId = permissionId
            };

            await _context.RolePermissions.AddAsync(rolePermission);
            await _context.SaveChangesAsync();

            return rolePermission.RoleId;
        }

        public async Task<int> AddRolePermissionRange(int roleId, IEnumerable<int> permissionIds)
        {
            throw new System.NotImplementedException();
        }
    }
}
