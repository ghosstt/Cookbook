using Cookbook.Api.Features.Ingredient.Dto;
using Cookbook.Api.Features.Ingredient.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient.Queries
{
    public class GetIngredientsHandler : IRequestHandler<GetIngredients, IEnumerable<IngredientDto>>
    {
        private readonly IIngredientService _service;

        public GetIngredientsHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<IngredientDto>> Handle(GetIngredients request, CancellationToken cancellationToken)
        {
            return await _service.GetIngredients(request.UserId);
        }
    }
}
