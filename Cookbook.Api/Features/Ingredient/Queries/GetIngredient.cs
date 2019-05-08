using Cookbook.Api.Features.Ingredient.Dto;
using MediatR;
using System;

namespace Cookbook.Api.Features.Ingredient.Queries
{
    public class GetIngredient : IRequest<IngredientDto>
    {
        public Guid UserId { get; }
        public int IngredientId { get; }

        public GetIngredient(Guid userId, int ingredientId)
        {
            UserId = userId;
            IngredientId = ingredientId;
        }
    }
}
