using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient
{
    public class GetIngredientsHandler : IRequestHandler<GetIngredients, IEnumerable<Entities.Ingredient>>
    {
        private readonly CookbookDbContext _context;

        public GetIngredientsHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Ingredient>> Handle(GetIngredients request, CancellationToken cancellationToken)
        {
            return await _context.Ingredients.Where(i => i.UserId == request.UserId).ToListAsync(cancellationToken);
        }
    }
}
