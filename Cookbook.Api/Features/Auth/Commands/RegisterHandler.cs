using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Auth.Services;
using System;

namespace Cookbook.Api.Features.Auth.Commands
{
    public class RegisterHandler : IRequestHandler<Register, CommandResult<Guid>>
    {
        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CommandResult<Guid>> Handle(Register request, CancellationToken cancellationToken)
        {
            Guid userId = await _authService.Register(request.RegisterDto);
            return CommandResult<Guid>.Success(userId);
        }
    }
}
