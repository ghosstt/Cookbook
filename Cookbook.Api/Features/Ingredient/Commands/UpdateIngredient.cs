using Cookbook.Api.Features.Common;
using Cookbook.Api.Features.Ingredient.Dto;
using MediatR;

namespace Cookbook.Api.Features.Ingredient.Commands
{
    public class UpdateIngredient : IRequest<CommandResult<int>>
    {
        public IngredientDto Ingredient { get; }

        public UpdateIngredient(IngredientDto ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
