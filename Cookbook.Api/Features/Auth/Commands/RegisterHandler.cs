using Cookbook.Api.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Cookbook.Api.Helpers;
using Cookbook.Api.Data.Entities;
using Cookbook.Api.Features.Common;

namespace Cookbook.Api.Features.Auth
{
    public class RegisterHandler : IRequestHandler<Register, CommandResult<int>>
    {
        private readonly CookbookDbContext _context;

        public RegisterHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<CommandResult<int>> Handle(Register request, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == request.UserName))
                throw new System.Exception("Username already exists");

            var user = new User();
            user.UserName = request.UserName.ToLower();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            byte[] passwordHash = null;
            byte[] passwordSalt = null;

            AuthHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CommandResult<int>.Success(user.UserId);
        }
    }
}
