using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe, CommandResult<int>>
    {
        private readonly IRecipeService _service;

        public UpdateRecipeHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            var recipeId = await _service.UpdateRecipe(request.RecipeDto);
            return CommandResult<int>.Success(recipeId);
        }
    }
}
