using Cookbook.Api.Data;
using Cookbook.Api.Data.Entities;
using Cookbook.Api.Features.Security.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Security.Services
{
    public class RoleService : IRoleService
    {
        private readonly CookbookDbContext _context;

        public RoleService(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRole(RoleDto roleDto)
        {
            if (await _context.Roles.AnyAsync(u => u.Name == roleDto.Name))
                throw new Exception("Role already exists");

            var role = new Role()
            {
                Name = roleDto.Name
            };

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return role.RoleId;
        }

        public async Task<int> UpdateRole(RoleDto roleDto)
        {
            if (await _context.Roles.AnyAsync(r => r.RoleId != roleDto.RoleId && r.Name == roleDto.Name))
                throw new Exception($"Error: Role '{roleDto.Name}' already exists");

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleDto.RoleId);
            if (role == null)
                throw new Exception($"Error: Role with ID: {roleDto.RoleId} not found ");

            role.Name = roleDto.Name;

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }

        public async Task<int> DeleteRole(int roleId)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);

            if (role == null)
                throw new Exception($"Error: Role with ID '{roleId}' does not exists");

            _context.Roles.Remove(role);
            return await _context.SaveChangesAsync();
        }
    }
}
