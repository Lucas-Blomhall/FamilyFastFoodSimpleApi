using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class DailyCaloricIntakeEntry
    {
        [Key]
        public int DailyCaloricIntakeEntryId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int CaloriesConsumed { get; set; }

    }
}
