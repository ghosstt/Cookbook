using MediatR;

namespace Cookbook.Api.Features.Recipe
{
    public class HasRecipeByName : IRequest<bool>
    {
        public string RecipeName { get; }

        public HasRecipeByName(string recipeName)
        {
            RecipeName = recipeName;
        }
    }
}
