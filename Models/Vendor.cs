using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Service Performed")]
        public string ServicePeformed { get; set; }
        public double ServiceBill { get; set; }
        public ICollection<Building_Vendor> Building_Vendors { get; set; }

    }
}
