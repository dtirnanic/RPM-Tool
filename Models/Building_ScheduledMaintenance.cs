using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class Building_ScheduledMaintenance
    {
        [ForeignKey("ScheduledMaintenance")]
        public int ScheduledMaintenanceId { get; set; }
        public ScheduledMaintenance ScheduledMaintenance { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

    }
}
