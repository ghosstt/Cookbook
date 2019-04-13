using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe
{
    public class HasRecipeByIdHandler : IRequestHandler<HasRecipeById, bool>
    {
        private readonly CookbookDbContext _context;

        public HasRecipeByIdHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(HasRecipeById request, CancellationToken cancellationToken)
        {
            return await _context.Recipes.AnyAsync(r => r.RecipeId == request.RecipeId);
        }
    }
}
