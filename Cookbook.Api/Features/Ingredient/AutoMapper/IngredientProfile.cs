using AutoMapper;
using Cookbook.Api.Features.Ingredient.Dto;
using Entities = Cookbook.Api.Data.Entities;

namespace Cookbook.Api.Features.Ingredient.AutoMapper
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Entities.Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Entities.Ingredient>();
        }
    }
}
