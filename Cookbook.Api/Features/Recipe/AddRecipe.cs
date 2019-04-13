using MediatR;

namespace Cookbook.Api.Features.Recipe
{
    public class AddRecipe : IRequest<int>
    {
        public Entities.Recipe Recipe { get; }

        public AddRecipe(Entities.Recipe recipe)
        {
            Recipe = recipe;
        }
    }
}
