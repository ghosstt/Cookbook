using Cookbook.Api.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Ingredients
{
    public class RemoveAllRecipeIngredientsHandler : IRequestHandler<RemoveAllRecipeIngredients, int>
    {
        private readonly CookbookDbContext _context;

        public RemoveAllRecipeIngredientsHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RemoveAllRecipeIngredients request, CancellationToken cancellationToken)
        {
            var remove = _context.RecipeIngredients.Where(ri => ri.RecipeId == request.RecipeId);
            _context.RecipeIngredients.RemoveRange(remove);
            return await _context.SaveChangesAsync();
        }
    }
}
