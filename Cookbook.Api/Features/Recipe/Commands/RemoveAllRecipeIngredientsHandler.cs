using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class RemoveAllRecipeIngredientsHandler : IRequestHandler<RemoveAllRecipeIngredients, CommandResult<int>>
    {
        private readonly IRecipeService _service;

        public RemoveAllRecipeIngredientsHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(RemoveAllRecipeIngredients request, CancellationToken cancellationToken)
        {
            var count = await _service.RemoveAllRecipeIngredients(request.RecipeId);
            return CommandResult<int>.Success(count);
        }
    }
}
