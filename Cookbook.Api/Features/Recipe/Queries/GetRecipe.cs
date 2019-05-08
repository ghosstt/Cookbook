using Cookbook.Api.Features.Recipe.Dto;
using MediatR;
using System;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipe : IRequest<RecipeDto>
    {
        public Guid UserId { get; }
        public int RecipeId { get; }

        public GetRecipe(Guid userId, int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
