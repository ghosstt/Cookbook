using Cookbook.Api.Data;
using Cookbook.Api.Entities;
using Cookbook.Api.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cookbook.Api.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CookbookDbContext _context;

        public AuthRepository(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash = null;
            byte[] passwordSalt = null;

            AuthHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
                return null;

            if (!AuthHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }


    }
}
