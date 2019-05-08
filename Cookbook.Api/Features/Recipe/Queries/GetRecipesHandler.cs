using Cookbook.Api.Features.Recipe.Dto;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipesHandler : IRequestHandler<GetRecipes, IEnumerable<RecipeDto>>
    {
        private readonly IRecipeService _service;

        public GetRecipesHandler(IRecipeService service)
        {
            this._service = service;
        }

        public async Task<IEnumerable<RecipeDto>> Handle(GetRecipes request, CancellationToken cancellationToken)
        {
            return await _service.GetRecipes(request.UserId);
        }
    }
}
