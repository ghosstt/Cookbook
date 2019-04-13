using Cookbook.Api.Data;
using Cookbook.Api.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Auth
{
    public class LoginHandler : IRequestHandler<Login, string>
    {
        private readonly IConfiguration _config;
        private readonly CookbookDbContext _context;

        public LoginHandler(IConfiguration config, CookbookDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<string> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null)
                throw new UnauthorizedAccessException("Unauthorized Access");

            if (!AuthHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new UnauthorizedAccessException("Unauthorized Access");

            string secretKey = _config.GetSection("AppSettings:SecretKey").Value;
            Claim[] claims = AuthHelper.GenerateClaims(user);

            return AuthHelper.GenerateToken(secretKey, claims);
        }
    }
}
