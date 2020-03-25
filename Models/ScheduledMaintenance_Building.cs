using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class ScheduledMaintenance_Building
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ScheduledMaintenance")]
        public int ScheduledMaintenanceId { get; set; }
        public ScheduledMaintenance ScheduledMaintenance { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

    }
}
