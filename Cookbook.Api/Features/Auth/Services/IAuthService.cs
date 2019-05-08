using Cookbook.Api.Features.Auth.Dto;
using System;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Auth.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto login);
        Task<Guid> Register(RegisterDto register);
    }
}
