using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class UpdateRecipeIngredientsHandler : IRequestHandler<UpdateRecipeIngredients, CommandResult<int>>
    {
        private readonly IRecipeService _service;

        public UpdateRecipeIngredientsHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(UpdateRecipeIngredients request, CancellationToken cancellationToken)
        {
            var count = await _service.UpdateRecipeIngredients(request.RecipeId, request.IngredientIds);
            return CommandResult<int>.Success(count);
        }
    }
}
