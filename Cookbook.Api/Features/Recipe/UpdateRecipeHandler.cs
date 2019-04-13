using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe, int>
    {
        private readonly CookbookDbContext _context;

        public UpdateRecipeHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            if (await _context.Recipes.AnyAsync(r => r.RecipeId != request.Recipe.RecipeId && r.Name == request.Recipe.Name))
                throw new System.Exception($"Error: Recipe '{request.Recipe.Name}' already exists");

            var rec = await _context.Recipes.FirstOrDefaultAsync(r => r.RecipeId == request.Recipe.RecipeId);
            if (rec == null)
                throw new System.Exception($"Error: Recipe with ID: {request.Recipe.RecipeId} not found ");

            rec.Name = request.Recipe.Name;
            rec.Description = request.Recipe.Description;
            rec.ImgSrc = request.Recipe.ImgSrc;

            _context.Recipes.Update(rec);
            await _context.SaveChangesAsync();
            return rec.RecipeId;
        }
    }
}
