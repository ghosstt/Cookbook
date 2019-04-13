using MediatR;

namespace Cookbook.Api.Features.Ingredient
{
    public class AddIngredient : IRequest<int>
    {
        public Entities.Ingredient Ingredient { get; }

        public AddIngredient(Entities.Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
