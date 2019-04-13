using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient
{
    public class GetIngredientHandler : IRequestHandler<GetIngredient, Entities.Ingredient>
    {
        private readonly CookbookDbContext _context;

        public GetIngredientHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Ingredient> Handle(GetIngredient request, CancellationToken cancellationToken)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.UserId == request.UserId && i.IngredientId == request.IngredientId, cancellationToken);
        }
    }
}
