using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Recipe.Dto;
using MediatR;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class UpdateRecipe : IRequest<CommandResult<int>>
    {
        public RecipeDto RecipeDto { get; }

        public UpdateRecipe(RecipeDto recipeDto)
        {
            RecipeDto = recipeDto;
        }
    }
}
