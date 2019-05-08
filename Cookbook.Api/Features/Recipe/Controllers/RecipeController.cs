using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Commands;
using Cookbook.Api.Features.Recipe.Dto;
using Cookbook.Api.Features.Recipe.Queries;
using Cookbook.Api.Helpers.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Cookbook.Api.Features.Recipe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRecipe(int recipeId)
        {
            Guid userId = User.GetUserId();
            var recipeDto = await _mediator.Send(new GetRecipe(userId, recipeId));
            return Ok(recipeDto);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetRecipes()
        {
            Guid userId = User.GetUserId();
            var recipesDto = await _mediator.Send(new GetRecipes(userId));
            return Ok(recipesDto);
        }

        [HttpGet("ingredients/ids")]
        public async Task<IActionResult> GetRecipeIngredientIds(int recipeId)
        {
            Guid userId = User.GetUserId();
            var recipeIngredientIds = await _mediator.Send(new GetRecipeIngredientIds(userId, recipeId));
            return Ok(recipeIngredientIds);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRecipe(RecipeDto recipeDto)
        {
            recipeDto.UserId = User.GetUserId();
            CommandResult<int> result = await _mediator.Send(new AddRecipe(recipeDto));
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecipe(RecipeDto recipeDto)
        {
            recipeDto.UserId = User.GetUserId();
            CommandResult<int> result = await _mediator.Send(new UpdateRecipe(recipeDto));
            return Ok(result);
        }
    }
}