using AutoMapper;
using Cookbook.Api.Features.Recipe.Dto;
using Entities = Cookbook.Api.Data.Entities;

namespace Cookbook.Api.Features.Recipe.AutoMapper
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Entities.Recipe, RecipeDto>();
            CreateMap<RecipeDto, Entities.Recipe>();
        }
    }
}
