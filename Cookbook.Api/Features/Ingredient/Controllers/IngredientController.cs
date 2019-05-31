using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Ingredient.Commands;
using Cookbook.Api.Features.Ingredient.Dto;
using Cookbook.Api.Features.Ingredient.Queries;
using Cookbook.Api.Helpers.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthorizationService _authService;

        public IngredientController(IMediator mediator, IAuthorizationService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetIngredient(int ingredientId)
        {
            Guid userId = User.GetUserId();
            var ingredient = await _mediator.Send(new GetIngredient(userId, ingredientId));
            return Ok(ingredient);
        }

        // [Authorize(Policy = "TestPolicy")]
        [HttpGet("list")]
        public async Task<IActionResult> GetIngredients()
        {
            var authorize = await _authService.AuthorizeAsync(user: User, resource: null, policyName: "TestPolicy");

            if (authorize.Succeeded)
            {
                Guid userId = User.GetUserId();
                var ingredients = await _mediator.Send(new GetIngredients(userId));
                return Ok(ingredients);
            }

            return Forbid();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIngredient(IngredientDto ingredientDto)
        {
            ingredientDto.UserId = User.GetUserId();
            CommandResult<int> result = await _mediator.Send(new AddIngredient(ingredientDto));
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateIngredient(IngredientDto ingredientDto)
        {
            ingredientDto.UserId = User.GetUserId();
            CommandResult<int> result = await _mediator.Send(new UpdateIngredient(ingredientDto));
            return Ok(result);
        }
    }
}