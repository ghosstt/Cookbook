using MediatR;
using System.Collections.Generic;

namespace Cookbook.Api.Features.Recipe
{
    public class GetRecipes : IRequest<IEnumerable<Entities.Recipe>>
    {
        public int UserId { get; }

        public GetRecipes(int userId)
        {
            UserId = userId;
        }
    }
}
