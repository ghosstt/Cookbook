using Cookbook.Api.Entities;
using System.Threading.Tasks;

namespace Cookbook.Api.Infrastructure.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
