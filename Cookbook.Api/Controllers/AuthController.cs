using Cookbook.Api.Data;
using Cookbook.Api.Dto;
using Cookbook.Api.Entities;
using Cookbook.Api.Helpers;
using Cookbook.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cookbook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, IAuthRepository repository)
        {
            _config = config;
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            userRegisterDto.UserName = userRegisterDto.UserName.ToLower();

            if (await _repository.UserExists(userRegisterDto.UserName))
                return BadRequest("Usernamem already exists");

            var user = new User()
            {
                UserName = userRegisterDto.UserName,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName
            };

            var createdUser = await _repository.Register(user, userRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            User user = await _repository.Login(userLoginDto.UserName.ToLower(), userLoginDto.Password);

            if (user == null)
                return Unauthorized();

            string secretKey = _config.GetSection("AppSettings:SecretKey").Value;
            Claim[] claims = AuthHelper.GenerateClaims(user);

            return Ok(new
            {
                token = AuthHelper.GenerateToken(secretKey, claims)
            });
        }

        // For testing purposes
        [HttpGet("seed")]
        public async Task<IActionResult> SeedUser()
        {
            List<User> users = new List<User>();

            users.Add(await _repository.Register(new User()
            {
                UserName = "johnpaul",
                FirstName = "John Paul",
                LastName = "Santos"
            }, "johnpaul"));

            users.Add(await _repository.Register(new User()
            {
                UserName = "nicole",
                FirstName = "Nicole",
                LastName = "Reyes"
            }, "nicole"));

            return Ok(users);
        }
    }
}