using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipeIngredientIds : IRequest<IEnumerable<int>>
    {
        public int UserId { get; }
        public int RecipeId { get; }

        public GetRecipeIngredientIds(int userId, int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
