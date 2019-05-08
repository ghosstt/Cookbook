using Cookbook.Api.Features.Auth.Dto;
using Cookbook.Api.Features.Common;
using MediatR;
using System;

namespace Cookbook.Api.Features.Auth.Commands
{
    public class Register : IRequest<CommandResult<Guid>>
    {
        public RegisterDto RegisterDto { get; }

        public Register(RegisterDto registerDto)
        {
            RegisterDto = registerDto;
        }
    }
}
