using Cookbook.Api.Features.Common;
using MediatR;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class RemoveAllRecipeIngredients : IRequest<CommandResult<int>>
    {
        public int RecipeId { get; }

        public RemoveAllRecipeIngredients(int recipeId)
        {
            RecipeId = recipeId;
        }
    }
}
