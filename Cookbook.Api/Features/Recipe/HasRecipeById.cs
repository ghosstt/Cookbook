using MediatR;

namespace Cookbook.Api.Features.Recipe
{
    public class HasRecipeById : IRequest<bool>
    {
        public int RecipeId { get; }

        public HasRecipeById(int recipeId)
        {
            RecipeId = recipeId;
        }
    }
}
