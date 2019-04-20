using Cookbook.Api.Features.Ingredient.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient.Services
{
    public interface IIngredientService
    {
        Task<IngredientDto> GetIngredient(int userId, int ingredientId);
        Task<IEnumerable<IngredientDto>> GetIngredients(int userId);

        Task<int> AddIngredient(IngredientDto ingredientDto);
        Task<int> UpdateIngredient(IngredientDto ingredientDto);
    }
}
