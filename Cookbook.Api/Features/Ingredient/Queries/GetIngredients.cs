using Cookbook.Api.Features.Ingredient.Dto;
using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Ingredient.Queries
{
    public class GetIngredients : IRequest<IEnumerable<IngredientDto>>
    {
        public int UserId { get; }

        public GetIngredients(int userId)
        {
            UserId = userId;
        }
    }
}
