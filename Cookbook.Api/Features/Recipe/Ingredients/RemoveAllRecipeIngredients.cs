using MediatR;

namespace Cookbook.Api.Features.Recipe.Ingredients
{
    public class RemoveAllRecipeIngredients : IRequest<int>
    {
        public int RecipeId { get; }

        public RemoveAllRecipeIngredients(int recipeId)
        {
            RecipeId = recipeId;
        }
    }
}
