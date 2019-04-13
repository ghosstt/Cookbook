using Cookbook.Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Ingredients
{
    public class GetRecipeIngredientIdsHandler : IRequestHandler<GetRecipeIngredientIds, IEnumerable<int>>
    {
        private readonly CookbookDbContext _context;

        public GetRecipeIngredientIdsHandler(CookbookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> Handle(GetRecipeIngredientIds request, CancellationToken cancellationToken)
        {
            var result = from r in _context.Recipes
                         join ri in _context.RecipeIngredients on r.RecipeId equals ri.RecipeId
                         where r.UserId == request.UserId && r.RecipeId == request.RecipeId
                         select ri.IngredientId;

            return await result.ToListAsync(cancellationToken);
        }
    }
}
