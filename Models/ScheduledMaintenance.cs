using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class ScheduledMaintenance
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Maintenance Item")]
        public string MaintenanceItem { get; set; }
        [Display(Name = "Scheduled Time")]
        public DateTime ScheduledTime { get; set; }
        public ICollection<ScheduledMaintenance_Building> ScheduledMaintenance_Buildings { get; set; }
    }
}
