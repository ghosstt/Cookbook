using AutoMapper;
using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Ingredient.Commands;
using Cookbook.Api.Features.Ingredient.Dto;
using Cookbook.Api.Features.Ingredient.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(ingredient);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetIngredients(int userId)
        {
            var ingredients = await _mediator.Send(new GetIngredients(userId));
            return Ok(ingredients);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIngredient(IngredientDto ingredientDto)
        {
            CommandResult<int> result = await _mediator.Send(new AddIngredient(ingredientDto));
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateIngredient(IngredientDto ingredientDto)
        {
            CommandResult<int> result = await _mediator.Send(new UpdateIngredient(ingredientDto));
            return Ok(result);
        }
    }
}