using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipeIngredientIdsHandler : IRequestHandler<GetRecipeIngredientIds, IEnumerable<int>>
    {
        private readonly IRecipeService _service;

        public GetRecipeIngredientIdsHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<int>> Handle(GetRecipeIngredientIds request, CancellationToken cancellationToken)
        {
            return await _service.GetRecipeIngredientIds(request.UserId, request.RecipeId);
        }
    }
}
