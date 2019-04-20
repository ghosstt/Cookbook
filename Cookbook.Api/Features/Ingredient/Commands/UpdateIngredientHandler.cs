using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Ingredient.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient.Commands
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient, CommandResult<int>>
    {
        private readonly IIngredientService _service;

        public UpdateIngredientHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            int ingredientId = await _service.UpdateIngredient(request.Ingredient);
            return CommandResult<int>.Success(ingredientId);
        }
    }
}