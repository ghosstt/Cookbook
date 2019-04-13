using MediatR;

namespace Cookbook.Api.Features.Ingredient
{
    public class UpdateIngredient : IRequest<int>
    {
        public Entities.Ingredient Ingredient { get; }

        public UpdateIngredient(Entities.Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
