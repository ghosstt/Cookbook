using MediatR;

namespace Cookbook.Api.Features.Recipe
{
    public class UpdateRecipe : IRequest<int>
    {
        public Entities.Recipe Recipe { get; }

        public UpdateRecipe(Entities.Recipe recipe)
        {
            Recipe = recipe;
        }
    }
}
