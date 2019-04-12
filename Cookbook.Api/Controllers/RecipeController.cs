using AutoMapper;
using Cookbook.Api.Dto;
using Cookbook.Api.Entities;
using Cookbook.Api.Infrastructure.Repositories;
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
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRecipe(int userId, int recipeId)
        {
            var recipe = await _repository.GetRecipe(userId, recipeId);
            var recipesDto = _mapper.Map<RecipeDto>(recipe);
            return Ok(recipesDto);
        }

        [HttpGet("ingredients/ids")]
        public async Task<IActionResult> GetRecipeIngredientIds(int userId, int recipeId)
        {
            var recipeIngredientIds = await _repository.GetRecipeIngredientIds(userId, recipeId);
            return Ok(recipeIngredientIds);
        }


        [HttpGet("list")]
        public async Task<IActionResult> GetRecipes(int userId)
        {
            var recipes = await _repository.GetRecipes(userId);
            var recipesDto = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return Ok(recipesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRecipe(RecipeDto recipeDto)
        {
            int recipeId = 0;

            if (recipeDto.RecipeId == 0)
            {
                if (await _repository.HasRecipe(recipeDto.Name))
                    return BadRequest("Recipe already exist");

                var recipe = _mapper.Map<Recipe>(recipeDto);
                recipeId = await _repository.AddRecipe(recipe);

                _repository.RemoveAllRecipeIngredients(recipeId);
                await _repository.AddRecipeIngredients(recipeId, recipeDto.IngredientIds);
            }
            else if (await _repository.HasRecipe(recipeDto.RecipeId))
            {
                recipeId = recipeDto.RecipeId;
                _repository.RemoveAllRecipeIngredients(recipeId);
                await _repository.AddRecipeIngredients(recipeId, recipeDto.IngredientIds);
            }

            return Ok(recipeId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecipe(RecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            var recipeId = await _repository.UpdateRecipe(recipe);

            _repository.RemoveAllRecipeIngredients(recipeId);
            await _repository.AddRecipeIngredients(recipeId, recipeDto.IngredientIds);

            return Ok(recipeId);
        }
    }
}