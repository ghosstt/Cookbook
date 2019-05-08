using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class AddRecipeIngredientIdsHandler : IRequestHandler<AddRecipeIngredientIds, CommandResult<int>>
    {
        private readonly IRecipeService _service;

        public AddRecipeIngredientIdsHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<CommandResult<int>> Handle(AddRecipeIngredientIds request, CancellationToken cancellationToken)
        {
            var count = await _service.AddRecipeIngredientIds(request.RecipeId, request.IngredientIds);
            return CommandResult<int>.Success(count);
        }
    }
}
