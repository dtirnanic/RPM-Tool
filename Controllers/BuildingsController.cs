﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPM_Tool.Data;
using RPM_Tool.Models;
using RPM_Tool.ViewModel;

namespace RPM_Tool.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuildingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()

        {
            return View(await _context.Buildings.ToListAsync());
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.BuildingId == id);
            var units = await _context.Units.Where(u => u.BuildingId == building.BuildingId).ToListAsync();
            ViewData["Units"] = units;
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: Buildings/Create
        [Authorize(Roles = "Landlord")] 
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Building building)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
                building.LandlordId = landlord.Id;
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LandlordId,UnitId,BuildingVendorId,MortgageEscrowId,BuildingUtilityId,ScheduledMaintenanceId")] Building building)
        {
            if (id != building.BuildingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.BuildingId)) 
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.BuildingId == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.BuildingId == id);
        }

        public async Task<IActionResult> BuildingsList()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            var buildings = _context.Buildings.Where(b => b.LandlordId == landlord.Id);

            double mortgageAndEscrowMoney = 0;
            foreach (var building in buildings)
            {
                var mortgage = _context.MortgageAndEscrows.Where(m => m.MortgageAndEscrowId == building.BuildingId).FirstOrDefault();
                if (mortgage == null)
                    mortgageAndEscrowMoney += 0;
                else
                    mortgageAndEscrowMoney += mortgage.MortgageAndEscrowBill; 
            }

            var buildingUtilities = await _context.Buildings.Where(b => b.LandlordId == landlord.Id) 
                .Include(building => building.Building_Utilities)
                .ThenInclude(utilities => utilities.Utility).ToListAsync();

            double utilityTotal = 0;
            foreach ( var building in buildingUtilities)
            {
                foreach ( var utility in building.Building_Utilities)
                {
                    utilityTotal += utility.Utility.Bill;
                }
            }

            var buildingVendors = await _context.Buildings.Where(b => b.LandlordId == landlord.Id)
                .Include(building => building.Building_Vendors)
                .ThenInclude(vendors => vendors.Vendor).ToListAsync();

            double vendorTotal = 0;
            foreach (var building in buildingVendors)
            {
                foreach (var vendor in building.Building_Vendors)
                {
                    vendorTotal += vendor.Vendor.ServiceBill;
                }
            }


            LandlordHomeViewModel landlordView = new LandlordHomeViewModel()
            {
                Buildings = await buildings.ToListAsync(),
                TotalMortgage = mortgageAndEscrowMoney,
                TotalUtility = utilityTotal,
                TotalVendor = vendorTotal
            };

            return View(landlordView);
            //return View(await buildings.ToListAsync());
        }

        // Get/ Create Scheduled Maintenance Item
        [Authorize(Roles = "Landlord")]
        public IActionResult AddScheduledMaintenanceItem()
        {

            //ScheduledMaintenance scheduledMaintenance = new ScheduledMaintenance();
            return View();//scheduledMaintenance);
        }

        [HttpPost]
        public async Task<IActionResult> AddScheduledMaintenanceItem(int id, ScheduledMaintenance scheduledMaintenance)
        {
            //landlord -> building -> scheduled maintenance_Building -> scheduledMaintenance
            var building = await _context.Buildings.FindAsync(id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            _context.Add(scheduledMaintenance);
            _context.SaveChanges();
            var buildingMaint = new Building_ScheduledMaintenance()
            {
                BuildingId = id,
                ScheduledMaintenanceId = scheduledMaintenance.ScheduledMaintenanceId
            };
            _context.Add(buildingMaint);
            _context.SaveChanges();

            return RedirectToAction("Details", "Buildings", new { id = id });

        }
        //get/create Uendor
        [Authorize(Roles = "Landlord")]
        public IActionResult AddVendor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVendor(int id, Vendor vendor)
        {
            var building = await _context.Buildings.FindAsync(id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            _context.Add(vendor);
            _context.SaveChanges();
            var buildingVendor = new Building_Vendor()
            {
                BuildingId = id,
                VendorId = vendor.VendorId
            };
            _context.Add(buildingVendor);
            _context.SaveChanges();
            return RedirectToAction("Details","Buildings",new { id = id });

        }

        //get/create Utility
        [Authorize(Roles = "Landlord")]
        public IActionResult AddUtility()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUtility(int id, Utility utility)
        {
            var building = await _context.Buildings.FindAsync(id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            _context.Add(utility);
            _context.SaveChanges();
            var buildingUtility = new Building_Utility()
            {
                BuildingId = id,
                UtilityId = utility.UtilityId
            };
            _context.Add(buildingUtility);
            _context.SaveChanges();
            return RedirectToAction("Details", "Buildings", new { id = id });
        }

        //get/create Mortgage and Escrow
        [Authorize(Roles = "Landlord")]
        public IActionResult AddMortgageAndEscrow() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMortgageAndEscrow(int id, MortgageAndEscrow mortgage)
        {
            var building = await _context.Buildings.FindAsync(id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            mortgage.BuildingId = id;
            _context.Add(mortgage);
            _context.SaveChanges();
            return RedirectToAction("Details", "Buildings", new { id = id });
        }

        //public void CreateRelationship(int id)
        //{
        //    Building_ScheduledMaintenance test = new Building_ScheduledMaintenance();
        //    var building = _context.Buildings.Find(id);
        //    var maint = _context.ScheduledMaintenances.Last();
        //    test.BuildingId = building.Id;
        //    test.ScheduledMaintenanceId = maint.Id;
        //    _context.Add(test);
        //    _context.SaveChanges();
        //}
    }
}
