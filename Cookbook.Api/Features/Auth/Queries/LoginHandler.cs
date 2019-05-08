using Cookbook.Api.Features.Auth.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Auth.Queries
{
    public class LoginHandler : IRequestHandler<Login, LoginResult>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginResult> Handle(Login request, CancellationToken cancellationToken)
        {
            return new LoginResult()
            {
                Token = await _authService.Login(request.LoginDto)
        };
        }
    }
}
