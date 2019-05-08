using Cookbook.Api.Features.Ingredient.Dto;
using Cookbook.Api.Features.Ingredient.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Api.Features.Ingredient.Queries
{
    public class GetIngredientHandler : IRequestHandler<GetIngredient, IngredientDto>
    {
        private readonly IIngredientService _service;

        public GetIngredientHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task<IngredientDto> Handle(GetIngredient request, CancellationToken cancellationToken)
        {
            return await _service.GetIngredient(request.UserId, request.IngredientId);
        }
    }
}
