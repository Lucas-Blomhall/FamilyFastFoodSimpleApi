using System.ComponentModel.DataAnnotations;

namespace FamilyFastFoodSimpleApi.DataModels
{
    public class UserLogins
    {
        [Key]
        public int UserLoginsId { get; set; }
        public string UserLoginsName { get; set; }
        public string UserLoginsPassword { get; set; }
        public int? UserCaloriesGoal { get; set; }
        public int? UserCaloriesConsumed { get; set; }
    }
}
