using Cookbook.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipe(int userId, int recipeId);
        Task<IEnumerable<Recipe>> GetRecipes(int userId);
        Task<IEnumerable<int>> GetRecipeIngredientIds(int userId, int recipeId);
        Task<bool> HasRecipe(int recipeId);
        Task<bool> HasRecipe(string recipeName);
        Task<int> AddRecipe(Recipe recipe);
        Task<int> UpdateRecipe(Recipe recipe);
        Task<int> AddRecipeIngredients(int recipeId, IEnumerable<int> ingredientIds);
        void RemoveAllRecipeIngredients(int recipeId);
        Task<int> SaveAll();
    }
}
