using Cookbook.Api.Data;
using Cookbook.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Cookbook.Api.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookbookDbContext _context;

        public RecipeRepository(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe> GetRecipe(int userId, int recipeId)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.UserId == userId && r.RecipeId == recipeId);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes(int userId)
        {
            return await _context.Recipes.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<int>> GetRecipeIngredientIds(int userId, int recipeId)
        {
            var result = from r in _context.Recipes
                         join ri in _context.RecipeIngredients on r.RecipeId equals ri.RecipeId
                         where r.UserId == userId && r.RecipeId == recipeId
                         select ri.IngredientId;

            return await result.ToListAsync();
        }

        public async Task<bool> HasRecipe(int recipeId)
        {
            return await _context.Recipes.AnyAsync(r => r.RecipeId == recipeId);
        }

        public async Task<bool> HasRecipe(string recipeName)
        {
            return await _context.Recipes.AnyAsync(r => r.Name == recipeName);
        }

        public async Task<int> AddRecipe(Recipe recipe)
        {
            var rec = await _context.Recipes.FirstOrDefaultAsync(r => r.Name == recipe.Name);
            if (rec != null)
                return 0;

            recipe.RecipeId = 0;
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return recipe.RecipeId;
        }

        public async Task<int> UpdateRecipe(Recipe recipe)
        {
            var rec = await _context.Recipes.FirstOrDefaultAsync(r => r.RecipeId == recipe.RecipeId);
            if (rec == null)
                return 0;

            rec.Name = recipe.Name;
            rec.Description = recipe.Description;
            rec.ImgSrc = recipe.ImgSrc;

            _context.Recipes.Update(rec);
            await _context.SaveChangesAsync();
            return rec.RecipeId;
        }

        public async Task<int> AddRecipeIngredients(int recipeId, IEnumerable<int> ingredientIds)
        {
            if (ingredientIds == null || ingredientIds.Count() == 0)
                return 0;

            var recipeIngredients = ingredientIds.Select(ingredientId => new RecipeIngredient()
            {
                RecipeId = recipeId,
                IngredientId = ingredientId
            }).AsEnumerable();

            await _context.RecipeIngredients.AddRangeAsync(recipeIngredients);
            return await _context.SaveChangesAsync();
        }

        public void RemoveAllRecipeIngredients(int recipeId)
        {
            var remove = _context.RecipeIngredients.Where(ri => ri.RecipeId == recipeId);
            _context.RecipeIngredients.RemoveRange(remove);
            _context.SaveChanges();
        }

        public async Task<int> SaveAll()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
