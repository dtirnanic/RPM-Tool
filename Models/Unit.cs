using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public int RentAmount { get; set; }
        public bool RentPaid { get; set; }

    }  

}
