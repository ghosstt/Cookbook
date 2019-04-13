using AutoMapper;
using Cookbook.Api.Dto;
using Cookbook.Api.Entities;
using Cookbook.Api.Features.Ingredient;
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
    public class IngredientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IngredientController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetIngredient(int userId, int ingredientId)
        {
            var ingredient = await _mediator.Send(new GetIngredient(userId, ingredientId));
            var ingredientsDto = _mapper.Map<IngredientDto>(ingredient);
            return Ok(ingredientsDto);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetIngredients(int userId)
        {
            var ingredients = await _mediator.Send(new GetIngredients(userId));
            var ingredientsDto = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            return Ok(ingredientsDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            var ingredientId = await _mediator.Send(new AddIngredient(ingredient));
            return Ok(ingredientId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            var ingredientId = await _mediator.Send(new UpdateIngredient(ingredient));
            return Ok(ingredientId);
        }
    }
}