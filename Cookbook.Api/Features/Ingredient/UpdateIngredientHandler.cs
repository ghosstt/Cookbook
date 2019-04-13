using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient, int>
    {
        private readonly CookbookDbContext _context;

        public UpdateIngredientHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            if (await _context.Ingredients.AnyAsync(i => i.IngredientId != request.Ingredient.IngredientId && i.Name == request.Ingredient.Name))
                throw new System.Exception($"Error: Ingredient '{request.Ingredient.Name}' already exists");

            var ing = await _context.Ingredients.FirstOrDefaultAsync(i => i.IngredientId == request.Ingredient.IngredientId);
            if (ing == null)
                throw new System.Exception($"Error: Ingredient with ID: {request.Ingredient.IngredientId} not found ");

            ing.Name = request.Ingredient.Name;
            ing.Description = request.Ingredient.Description;
            ing.ImgSrc = request.Ingredient.ImgSrc;

            _context.Ingredients.Update(ing);
            await _context.SaveChangesAsync();
            return ing.IngredientId;
        }
    }
}