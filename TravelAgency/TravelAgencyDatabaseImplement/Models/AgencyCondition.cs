using System.ComponentModel.DataAnnotations;

namespace TravelAgencyDatabaseImplement.Models
{
    public class AgencyCondition
    {
        public int Id { get; set; }

        public int ConditionId { get; set; }

        public int TravelAgencyId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual Agency TravelAgency { get; set; }
    }
}
