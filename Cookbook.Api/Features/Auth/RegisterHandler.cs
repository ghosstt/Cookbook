using Cookbook.Api.Data;
using Cookbook.Api.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Cookbook.Api.Helpers;

namespace Cookbook.Api.Features.Auth
{
    public class RegisterHandler : IRequestHandler<Register, User>
    {
        private readonly CookbookDbContext _context;

        public RegisterHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(Register request, CancellationToken cancellationToken)
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

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
