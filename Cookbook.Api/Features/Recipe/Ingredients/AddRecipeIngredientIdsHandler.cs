using Cookbook.Api.Data;
using Cookbook.Api.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Ingredients
{
    public class AddRecipeIngredientIdsHandler : IRequestHandler<AddRecipeIngredientIds, int>
    {
        private readonly CookbookDbContext _context;

        public AddRecipeIngredientIdsHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddRecipeIngredientIds request, CancellationToken cancellationToken)
        {
            if (request.IngredientIds == null || request.IngredientIds.Count() == 0)
                return 0;

            var recipeIngredients = request.IngredientIds.Select(ingredientId => new RecipeIngredient()
            {
                RecipeId = request.RecipeId,
                IngredientId = ingredientId
            }).AsEnumerable();

            await _context.RecipeIngredients.AddRangeAsync(recipeIngredients);
            return await _context.SaveChangesAsync();
        }
    }
}
