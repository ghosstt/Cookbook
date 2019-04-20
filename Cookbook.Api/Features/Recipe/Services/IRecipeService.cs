using Cookbook.Api.Features.Recipe.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Services
{
    public interface IRecipeService
    {
        Task<int> AddRecipe(RecipeDto recipe);
        Task<int> UpdateRecipe(RecipeDto recipe);
        Task<RecipeDto> GetRecipe(int userId, int recipeId);
        Task<IEnumerable<RecipeDto>> GetRecipes(int userId);
        Task<bool> HasRecipe(int recipeId);
        Task<bool> HasRecipe(string recipeName);


        Task<int> UpdateRecipeIngredients(int recipeId, IEnumerable<int> ingredientIds);
        Task<int> AddRecipeIngredientIds(int recipeId, IEnumerable<int> ingredientIds);
        Task<int> RemoveAllRecipeIngredients(int recipeId);
        Task<IEnumerable<int>> GetRecipeIngredientIds(int userId, int recipeId);
    }
}
