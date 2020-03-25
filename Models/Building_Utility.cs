using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class Building_Utility
    {
        [ForeignKey("Utility")]
        public int UtilityId { get; set; }
        public Utility Utility { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
