using Cookbook.Api.Data;
using Cookbook.Api.Features.Auth.Dto;
using Cookbook.Api.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly CookbookDbContext _context;
        private readonly JwtOptions _jwtOptions;

        public AuthService(CookbookDbContext context, JwtOptions jwtOptions)
        {
            _context = context;
            _jwtOptions = jwtOptions;
        }

        public async Task<string> Login(LoginDto login)
        {
            var user = await _context.Users.Include(c => c.UserPermissions).FirstOrDefaultAsync(u => u.UserName == login.UserName);

            if (user == null)
                throw new UnauthorizedAccessException("Unauthorized Access");

            if (!AuthHelper.VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
                throw new UnauthorizedAccessException("Unauthorized Access");

            Claim[] claims = AuthHelper.GenerateClaims(user);
            return AuthHelper.GenerateTokenV2(_jwtOptions, claims);
        }

        public async Task<Guid> Register(RegisterDto register)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == register.UserName))
                throw new Exception("Username already exists");

            var user = new Data.Entities.User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName.ToLower(),
                EmailAddress = register.EmailAddress
            };

            AuthHelper.CreatePasswordHash(register.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.UserId;
        }
    }
}
