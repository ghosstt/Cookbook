using Cookbook.Api.Features.Common;
using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Commands
{
    public class AddRecipeIngredientIds : IRequest<CommandResult<int>>
    {
        public int RecipeId { get; }
        public IEnumerable<int> IngredientIds { get; }

        public AddRecipeIngredientIds(int recipeId, IEnumerable<int> ingredientIds)
        {
            RecipeId = recipeId;
            IngredientIds = ingredientIds;
        }
    }
}
