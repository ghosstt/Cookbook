using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe
{
    public class AddRecipeHandler : IRequestHandler<AddRecipe, int>
    {
        private readonly CookbookDbContext _context;

        public AddRecipeHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddRecipe request, CancellationToken cancellationToken)
        {
            if (await _context.Recipes.AnyAsync(r => r.Name == request.Recipe.Name))
                throw new System.Exception($"Error: Recipe '{request.Recipe.Name}' already exists");

            request.Recipe.RecipeId = 0;
            await _context.Recipes.AddAsync(request.Recipe);
            await _context.SaveChangesAsync();
            return request.Recipe.RecipeId;
        }
    }
}
