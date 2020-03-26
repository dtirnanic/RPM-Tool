using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class ScheduledMaintenance
    {
   
        public int ScheduledMaintenanceId { get; set; }
 
        [Display(Name = "Maintenance Item")]
        public string MaintenanceItem { get; set; }
        [Display(Name = "Scheduled Time")]
        public DateTime ScheduledTime { get; set; }

        public ICollection<Building_ScheduledMaintenance> Building_ScheduledMaintenances { get; set; }
    }
}
