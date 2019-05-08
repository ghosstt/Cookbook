using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Ingredient.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient.Commands
{
    public class AddIngredientHandler : IRequestHandler<AddIngredient, CommandResult<int>>
    {
        private readonly IIngredientService _service;

        public AddIngredientHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(AddIngredient request, CancellationToken cancellationToken)
        {
            int ingredientId = await _service.AddIngredient(request.Ingredient);
            return CommandResult<int>.Success(ingredientId);
        }
    }
}
