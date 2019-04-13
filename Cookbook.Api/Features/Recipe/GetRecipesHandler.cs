using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe
{
    public class GetRecipesHandler : IRequestHandler<GetRecipes, IEnumerable<Entities.Recipe>>
    {
        private readonly CookbookDbContext _context;

        public GetRecipesHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Recipe>> Handle(GetRecipes request, CancellationToken cancellationToken)
        {
            return await _context.Recipes.Where(r => r.UserId == request.UserId).ToListAsync(cancellationToken);
        }
    }
}
