using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Ingredient.Dto;
using MediatR;

namespace Cookbook.Api.Features.Ingredient.Commands
{
    public class AddIngredient : IRequest<CommandResult<int>>
    {
        public IngredientDto Ingredient { get; }

        public AddIngredient(IngredientDto ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
