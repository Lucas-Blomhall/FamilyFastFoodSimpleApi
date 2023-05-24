using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class Ingredients
    {
        [Key]
        public int IngredientsID { get; set; }
        public string IngredientsName { get; set; }
        public double Protein { get; set; }
        public int Calories { get; set; }

        public double? TotalCarbohydrates { get; set; }
        public double? TotalFat { get; set; }
        public double? SaturatedFat { get; set; }
        public double? TransFat { get; set; }
        public double? Cholesterol { get; set; }
        public double? Sodium { get; set; }
        public double? DietaryFiber { get; set; }
        public double? Sugars { get; set; }
        public double? VitaminA { get; set; }
        public double? VitaminC { get; set; }
        public double? Calcium { get; set; }
        public double? Iron { get; set; }
    }
}
