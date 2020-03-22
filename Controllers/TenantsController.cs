using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPM_Tool.Data;
using RPM_Tool.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace RPM_Tool.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TenantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tenants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tenants.Include(t => t.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .Include(t => t.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        public IActionResult Create()
        {
            var unitlist = _context.Units;
            var tenant = new TenantViewModel();
            foreach (Unit unit in unitlist)
            {
                tenant.Units.Add(unit);
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(tenant);
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TenantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Tenant tenant = new Tenant()
                {
                    IdentityUserId = userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UnitId = model.UnitId
                };
                               
                _context.Add(tenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UnitId"] = new SelectList(_context.Users, "Id", "Unit Number", model.Units.FirstOrDefault());
            return View();
        }

        // GET: Tenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tenant.IdentityUserId);
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,TenantMaintenanceRequestId,FirstName,LastName,PhoneNumber")] Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tenant.IdentityUserId);
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .Include(t => t.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantExists(int id)
        {
            return _context.Tenants.Any(e => e.Id == id);
        }

        public async Task<IActionResult> MaintenanceRequest(int id)
        {
            //tenant -> unit -> building -> landlord
            //we need landlord phone #
            //send text message (twilio)
            var tenant = await _context.Tenants.FindAsync(id);
            var unit = await _context.Units.FindAsync(tenant.UnitId);
            var building = await _context.Buildings.FindAsync(unit.BuildingId);
            var landlord = await _context.Landlords.FindAsync(building.LandlordId);
            //https://www.twilio.com/docs/libraries/csharp-dotnet
            TwilioClient.Init("AC78487dbd904b432a52806f8f5473598a", "268868afbe3ffbe6922d56d817023e1c");  //account id, auth token
            var to = new PhoneNumber($"+1{landlord.PhoneNumber}");
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber(@"+14144486404"),  //twilio number
                body: $"{tenant.FirstName} {tenant.LastName} has made a maintenance request");
            return RedirectToAction(nameof(Details), id);
        }
    }
}
