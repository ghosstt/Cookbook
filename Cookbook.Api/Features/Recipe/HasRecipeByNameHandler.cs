using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe
{
    public class HasRecipeByNameHandler : IRequestHandler<HasRecipeByName, bool>
    {
        private readonly CookbookDbContext _context;

        public HasRecipeByNameHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(HasRecipeByName request, CancellationToken cancellationToken)
        {
            return await _context.Recipes.AnyAsync(r => r.Name == request.RecipeName);
        }
    }
}
