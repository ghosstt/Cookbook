using AutoMapper;
using Cookbook.Api.Dto;
using Cookbook.Api.Entities;
using Cookbook.Api.Features.Recipe;
using Cookbook.Api.Features.Recipe.Ingredients;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RecipeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRecipe(int userId, int recipeId)
        {
            var recipe = await _mediator.Send(new GetRecipe(userId, recipeId));
            var recipesDto = _mapper.Map<RecipeDto>(recipe);
            return Ok(recipesDto);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetRecipes(int userId)
        {
            var recipes = await _mediator.Send(new GetRecipes(userId));
            var recipesDto = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return Ok(recipesDto);
        }

        [HttpGet("ingredients/ids")]
        public async Task<IActionResult> GetRecipeIngredientIds(int userId, int recipeId)
        {
            var recipeIngredientIds = await _mediator.Send(new GetRecipeIngredientIds(userId, recipeId));
            return Ok(recipeIngredientIds);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRecipe(RecipeDto recipeDto)
        {
            int recipeId = 0;

            if (recipeDto.RecipeId == 0)
            {
                var recipe = _mapper.Map<Recipe>(recipeDto);
                recipeId = await _mediator.Send(new AddRecipe(recipe));
                await _mediator.Send(new RemoveAllRecipeIngredients(recipeId));
                await _mediator.Send(new AddRecipeIngredientIds(recipeId, recipeDto.IngredientIds));
            }
            else if (await _mediator.Send(new HasRecipeById(recipeDto.RecipeId)))
            {
                recipeId = recipeDto.RecipeId;
                await _mediator.Send(new RemoveAllRecipeIngredients(recipeId));
                await _mediator.Send(new AddRecipeIngredientIds(recipeId, recipeDto.IngredientIds));
            }

            return Ok(recipeId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecipe(RecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            var recipeId = await _mediator.Send(new UpdateRecipe(recipe));
            await _mediator.Send(new RemoveAllRecipeIngredients(recipeId));
            await _mediator.Send(new AddRecipeIngredientIds(recipeId, recipeDto.IngredientIds));
            return Ok(recipeId);
        }
    }
}