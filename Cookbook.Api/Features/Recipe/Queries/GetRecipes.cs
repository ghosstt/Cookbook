using Cookbook.Api.Features.Recipe.Dto;
using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipes : IRequest<IEnumerable<RecipeDto>>
    {
        public int UserId { get; }

        public GetRecipes(int userId)
        {
            UserId = userId;
        }
    }
}
