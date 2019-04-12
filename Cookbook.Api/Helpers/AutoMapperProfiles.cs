using AutoMapper;
using Cookbook.Api.Dto;
using Cookbook.Api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Ingredient, IngredientDto>();

            CreateMap<RecipeDto, Recipe>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
