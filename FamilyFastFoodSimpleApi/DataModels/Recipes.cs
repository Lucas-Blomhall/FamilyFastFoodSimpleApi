using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class Recipes
    {
        [Key]
        public int RecipesID { get; set; }
        public string RecipesTitle { get; set; }
        public string? Description { get; set; }
        public string? PrepTime { get; set; }
        public string? TotalTime { get; set; }
        public int? ServingSize { get; set; }
        public string? ImageURL { get; set; }

        public string Stepbystep1 { get; set; }
        public string? Stepbystep2 { get; set; }
        public string? Stepbystep3 { get; set; }
        public string? Stepbystep4 { get; set; }
        public string? Stepbystep5 { get; set; }
        public string? Stepbystep6 { get; set; }

        public int? CategoriesId { get; set; }
        public int? CuisinesId { get; set; }
        public int? TagsId { get; set; }

        public int IngredientsID1 { get; set; }
        public int? IngredientsID2 { get; set; }
        public int? IngredientsID3 { get; set; }
        public int? IngredientsID4 { get; set; }
        public int? IngredientsID5 { get; set; }
    }
}
