using Cookbook.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Infrastructure.Repositories
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetIngredient(int userId, int ingredientId);
        Task<IEnumerable<Ingredient>> GetIngredients(int userId);
        Task<int> AddIngredient(Ingredient ingredient);
        Task<int> UpdateIngredient(Ingredient ingredient);
    }
}
