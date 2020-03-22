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
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        [Display(Name = "Unit Number")]
        public string UnitNumber { get; set; }
        [Display(Name = "Rent Amount")]
        public int RentAmount { get; set; }
        [Display(Name = "Rent paid for the month")]
        public bool RentPaid { get; set; }

    }  

}
