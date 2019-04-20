using AutoMapper;
using Cookbook.Api.Data.Entities;
using Cookbook.Api.Features.Ingredient.Dto;

namespace Cookbook.Api.Helpers
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
