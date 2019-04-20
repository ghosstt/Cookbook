using AutoMapper;
using Cookbook.Api.Data.Entities;
using Cookbook.Api.Features.Recipe.Dto;

namespace Cookbook.Api.Helpers
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDto, Recipe>();
        }
    }
}
