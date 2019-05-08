using Cookbook.Api.Features.Auth.Dto;
using MediatR;

namespace Cookbook.Api.Features.Auth.Queries
{
    public class Login : IRequest<LoginResult>
    {
        public LoginDto LoginDto { get; }

        public Login(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}
