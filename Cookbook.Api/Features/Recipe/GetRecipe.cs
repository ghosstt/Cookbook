using MediatR;

namespace Cookbook.Api.Features.Recipe
{
    public class GetRecipe : IRequest<Entities.Recipe>
    {
        public int UserId { get; }
        public int RecipeId { get; }

        public GetRecipe(int userId, int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
