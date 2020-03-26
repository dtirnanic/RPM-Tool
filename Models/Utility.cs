using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class Utility
    {
        [Key]
        public int UtilityId { get; set; }
        [Display(Name = "Utility Provider")]
        public string UtilityProvider { get; set; }
        [Display(Name = "Utility Type")]
        public string UtilityType { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public double Bill { get; set; }

        public ICollection<Building_Utility> Building_Utilities { get; set; }
    }
}

