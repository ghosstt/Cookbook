using Cookbook.Api.Features.Ingredient.Dto;
using MediatR;

namespace Cookbook.Api.Features.Ingredient.Queries
{
    public class GetIngredient : IRequest<IngredientDto>
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
