using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class Tags
    {
        [Key]
        public int TagsId { get; set; }
        public string TagsName { get; set; }
    }
}
