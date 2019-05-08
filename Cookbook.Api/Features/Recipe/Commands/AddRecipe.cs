using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Dto;
using MediatR;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class AddRecipe : IRequest<CommandResult<int>>
    {
        public RecipeDto RecipeDto { get; }

        public AddRecipe(RecipeDto recipeDto)
        {
            RecipeDto = recipeDto;
        }
    }
}
