using RPM_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.ViewModel
{
    public class LandlordHomeViewModel
    {
        public List<Building> Buildings { get; set; }
        public double TotalMortgage { get; set; }
        public double TotalUtility { get; set; }
        public double TotalVendor { get; set; }
    }
}
