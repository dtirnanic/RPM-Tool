using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class MortgageAndEscrow
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Mortgage Provider")]
        public string MortgageProvider {get;set;}
        [Display(Name = "Mortgage and Escrow Bill")]
        public string MortgageAndEscrowBill { get; set; }

    }
}
