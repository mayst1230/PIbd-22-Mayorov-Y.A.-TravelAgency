using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyDatabaseImplement.Models
{
    public class Condition
    {
        public int Id { get; set; }

        [Required]
        public string ConditionName { get; set; }

        [ForeignKey("ConditionId")]
        public virtual List<TravelCondition> TravelConditions { get; set; }

        [ForeignKey("ConditionId")]
        public virtual List<AgencyCondition> TravelAgencyConditions { get; set; }
    }
}
