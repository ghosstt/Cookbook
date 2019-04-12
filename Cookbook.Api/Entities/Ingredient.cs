namespace Cookbook.Api.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }
    }
}
