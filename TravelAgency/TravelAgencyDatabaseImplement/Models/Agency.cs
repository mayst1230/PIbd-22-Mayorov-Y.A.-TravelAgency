using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyDatabaseImplement.Models
{
    public class Agency
    {
        public int Id { get; set; }

        [Required]
        public string TravelAgencyName { get; set; }

        [Required]
        public string FullNameResponsible { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("TravelAgencyId")]
        public virtual List<AgencyCondition> TravelAgencyConditions { get; set; }
    }
}
