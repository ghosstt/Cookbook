using Cookbook.Api.Features.Ingredient.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Ingredient.Queries
{
    public class GetIngredients : IRequest<IEnumerable<IngredientDto>>
    {
        public Guid UserId { get; }

        public GetIngredients(Guid userId)
        {
            UserId = userId;
        }
    }
}
