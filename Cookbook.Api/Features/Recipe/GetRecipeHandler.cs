using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe
{
    public class GetRecipeHandler : IRequestHandler<GetRecipe, Entities.Recipe>
    {
        private readonly CookbookDbContext _context;

        public GetRecipeHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Recipe> Handle(GetRecipe request, CancellationToken cancellationToken)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.UserId == request.UserId && r.RecipeId == request.RecipeId, cancellationToken);
        }
    }
}
