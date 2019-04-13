using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient
{
    public class AddIngredientHandler : IRequestHandler<AddIngredient, int>
    {
        private readonly CookbookDbContext _context;

        public AddIngredientHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddIngredient request, CancellationToken cancellationToken)
        {
            if (await _context.Recipes.AnyAsync(i => i.Name == request.Ingredient.Name))
                throw new System.Exception($"Error: Ingredient '{request.Ingredient.Name}' already exists");

            request.Ingredient.IngredientId = 0;
            await _context.Ingredients.AddAsync(request.Ingredient, cancellationToken);
            await _context.SaveChangesAsync();
            return request.Ingredient.IngredientId;
        }
    }
}
