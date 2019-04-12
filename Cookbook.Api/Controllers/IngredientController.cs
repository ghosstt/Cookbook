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
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetIngredient(int userId, int ingredientId)
        {
            var ingredient = await _repository.GetIngredient(userId, ingredientId);
            var ingredientsDto = _mapper.Map<IngredientDto>(ingredient);
            return Ok(ingredientsDto);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetIngredients(int userId)
        {
            var ingredients = await _repository.GetIngredients(userId);
            var ingredientsDto = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            return Ok(ingredientsDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            var ingredientId = await _repository.AddIngredient(ingredient);
            return Ok(ingredientId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            var ingredientId = await _repository.UpdateIngredient(ingredient);
            return Ok(ingredientId);
        }
    }
}