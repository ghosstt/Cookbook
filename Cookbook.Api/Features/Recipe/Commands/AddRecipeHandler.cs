using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class AddRecipeHandler : IRequestHandler<AddRecipe, CommandResult<int>>
    {
        private readonly IRecipeService _service;

        public AddRecipeHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(AddRecipe request, CancellationToken cancellationToken)
        {
            var recipeId = await _service.AddRecipe(request.RecipeDto);
            return CommandResult<int>.Success(recipeId);
        }
    }
}
