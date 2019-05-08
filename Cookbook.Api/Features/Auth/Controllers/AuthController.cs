using Cookbook.Api.Features.Auth.Commands;
using Cookbook.Api.Features.Auth.Dto;
using Cookbook.Api.Features.Auth.Queries;
using Cookbook.Api.Features.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            CommandResult<Guid> result = await _mediator.Send(new Register(registerDto));
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            LoginResult result = await _mediator.Send(new Login(loginDto));
            return Ok(result);
        }
    }
}