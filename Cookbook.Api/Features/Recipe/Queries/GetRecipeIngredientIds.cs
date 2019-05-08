using MediatR;
using System;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipeIngredientIds : IRequest<IEnumerable<int>>
    {
        public Guid UserId { get; }
        public int RecipeId { get; }

        public GetRecipeIngredientIds(Guid userId, int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
