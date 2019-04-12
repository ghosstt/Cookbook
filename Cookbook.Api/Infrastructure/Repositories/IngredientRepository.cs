using Cookbook.Api.Data;
using Cookbook.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Api.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly CookbookDbContext _context;

        public IngredientRepository(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> GetIngredient(int userId, int ingredientId)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.UserId == userId && i.IngredientId == ingredientId);
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients(int userId)
        {
            return await _context.Ingredients.Where(i => i.UserId == userId).ToListAsync();
        }

        public async Task<int> AddIngredient(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateIngredient(Ingredient ingredient)
        {
            var ing = await _context.Ingredients.FirstOrDefaultAsync(r => r.IngredientId == ingredient.IngredientId);
            if (ing == null)
                return 0;

            ing.Name = ingredient.Name;
            ing.Description = ingredient.Description;
            ing.ImgSrc = ingredient.ImgSrc;

            _context.Ingredients.Update(ing);
            await _context.SaveChangesAsync();
            return ing.IngredientId;
        }
    }
}

