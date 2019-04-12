namespace Cookbook.Api.Dto
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }
    }
}
