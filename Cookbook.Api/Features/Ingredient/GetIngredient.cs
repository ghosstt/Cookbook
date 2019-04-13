using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Ingredient
{
    public class GetIngredient : IRequest<Entities.Ingredient>
    {
        public int UserId { get; }
        public int IngredientId { get; }

        public GetIngredient(int userId, int ingredientId)
        {
            UserId = userId;
            IngredientId = ingredientId;
        }
    }
}
