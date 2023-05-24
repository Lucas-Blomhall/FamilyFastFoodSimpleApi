using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class Categories
    {
        [Key]
        public int CategoriesId { get; set; }
        public string CategoriesName { get; set;}
    }
}
