using System;

namespace Cookbook.Api.Features.Ingredient.Dto
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }
    }
}
