using Cookbook.Api.Features.Recipe.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipes : IRequest<IEnumerable<RecipeDto>>
    {
        public Guid UserId { get; }

        public GetRecipes(Guid userId)
        {
            UserId = userId;
        }
    }
}
