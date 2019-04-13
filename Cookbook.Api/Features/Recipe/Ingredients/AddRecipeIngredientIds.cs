using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Ingredients
{
    public class AddRecipeIngredientIds : IRequest<int>
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
