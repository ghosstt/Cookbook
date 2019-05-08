using System;
using System.Collections.Generic;

namespace Cookbook.Api.Data.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
