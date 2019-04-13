using Cookbook.Api.Data;
using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Ingredient
{
    public class GetIngredients : IRequest<IEnumerable<Entities.Ingredient>>
    {
        public int UserId { get; }

        public GetIngredients(int userId)
        {
            UserId = userId;
        }
    }
}
