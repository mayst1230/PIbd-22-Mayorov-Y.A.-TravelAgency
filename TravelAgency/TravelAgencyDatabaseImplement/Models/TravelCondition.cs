using System.ComponentModel.DataAnnotations;

namespace TravelAgencyDatabaseImplement.Models
{
    public class TravelCondition
    {
        public int Id { get; set; }
        public int TravelId { get; set; }
        public int ConditionId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Travel Travel { get; set; }
    }
}
