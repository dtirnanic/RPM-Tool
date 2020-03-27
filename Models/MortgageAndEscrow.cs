using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class MortgageAndEscrow
    {
        [Key]
        public int MortgageAndEscrowId { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        [Display(Name = "Mortgage Provider")]
        public string MortgageProvider {get;set;}
        [Display(Name = "Mortgage and Escrow Bill")]
        public double MortgageAndEscrowBill { get; set; }

    }
}
