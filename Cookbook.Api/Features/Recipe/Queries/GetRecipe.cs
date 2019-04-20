using Cookbook.Api.Features.Recipe.Dto;
using MediatR;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipe : IRequest<RecipeDto>
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
