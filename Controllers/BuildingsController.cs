using System;
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
                .FirstOrDefaultAsync(m => m.Id == id);
            var units = await _context.Units.Where(u => u.BuildingId == building.Id).ToListAsync();
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
            if (id != building.Id)
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
                    if (!BuildingExists(building.Id)) 
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Buildings.Any(e => e.Id == id);
        }

        public async Task<IActionResult> BuildingsList()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            var buildings = _context.Buildings.Where(b => b.LandlordId == landlord.Id);
            return View(await buildings.ToListAsync());
        }

        [Authorize(Roles = "Landlord")]
        public IActionResult AddScheduledMaintenanceItem()
        {

            ScheduledMaintenance scheduledMaintenance = new ScheduledMaintenance();
            return View(scheduledMaintenance);
        }

        [HttpPost]
        public async Task<IActionResult> AddScheduledMaintenanceItem(int id, ScheduledMaintenance scheduledMaintenance)
        {
            //landlord -> building -> scheduled maintenance_Building -> scheduledMaintenance
            var building = await _context.Buildings.FindAsync(id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var landlord = _context.Landlords.Where(l => l.IdentityUserId == userId).FirstOrDefault();
            _context.ScheduledMaintenances.Add(scheduledMaintenance);
            //await _context.SaveChangesAsync(); 
            _context.SaveChanges();
            CreateRelationship(id);
            return RedirectToAction(nameof(Details)); 

        }

        public void CreateRelationship(int id)
        {
            ScheduledMaintenance_Building test = new ScheduledMaintenance_Building();
            var building = _context.Buildings.Find(id);
            var maint = _context.ScheduledMaintenances.Last();
            test.BuildingId = building.Id;
            test.ScheduledMaintenanceId = maint.Id;
            _context.Add(test);
            _context.SaveChanges();
        }
    }
}
