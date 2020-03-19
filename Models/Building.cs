using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Landlord")]
        public int LandlordId { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        [ForeignKey("BuildingVendor")]
        public int BuildingVendorId { get; set; }
        [ForeignKey("MortgageEscrow")]
        public int MortgageEscrowId { get; set; }
        [ForeignKey("BuildingUtility")]
        public int BuildingUtilityId { get; set; }
        [ForeignKey("ScheduledMaintenance")]
        public int ScheduledMaintenanceId { get; set; }

        public ICollection<Building_Vendor> Building_Vendors { get; set; }

        public ICollection<Building_Utility> Building_Utilities { get; set; }
        public ICollection<ScheduledMaintenance_Building> ScheduledMaintenance_Buildings  { get; set; }
    }
}
