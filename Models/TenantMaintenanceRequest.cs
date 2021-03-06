﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class TenantMaintenanceRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        [Display(Name = "Maintenance Request")]
        public string MaintenanceRequest { get; set; }
        public string Urgency { get; set; }


    }
}
