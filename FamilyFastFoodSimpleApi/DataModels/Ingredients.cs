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
        public double? VolumeMl { get; set; }
        public double? WeightGram { get; set; }

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

        // Nya fält!
        public double Cost { get; set; } // Hur mycket det kostar i tal och decimal
        public string? WhereToGet { get; set; } // Namnet på affären som man kan köpa den ifrån
        public string? Notes { get; set; } // Om ingredienten är för vattning.
        public double? Rating { get; set; } // assuming a rating scale of 1 to 5, adjust if necessary
    }
}
