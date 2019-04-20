using Cookbook.Api.Features.Recipe.Dto;
using Cookbook.Api.Features.Recipe.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Recipe.Queries
{
    public class GetRecipeHandler : IRequestHandler<GetRecipe, RecipeDto>
    {
        private readonly IRecipeService _service;

        public GetRecipeHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task<RecipeDto> Handle(GetRecipe request, CancellationToken cancellationToken)
        {
            return await _service.GetRecipe(request.UserId, request.RecipeId);
        }
    }
}
