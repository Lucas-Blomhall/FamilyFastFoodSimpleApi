using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class Cuisines
    {
        [Key]
        public int CuisinesId { get; set; }
        public string CuisinesName { get; set; }

    }
}
