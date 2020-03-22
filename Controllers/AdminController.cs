using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPM_Tool.Data;
using RPM_Tool.Models;

namespace RPM_Tool.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var twilioAccounts = _context.TwilioAccounts.ToList();
            return View(twilioAccounts);
        }

        public IActionResult Create()
        {
            var twilioAccount = new TwilioAccount();
            return View(twilioAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TwilioAccount twilioAccount)
        {
            if (ModelState.IsValid)
            {               
                _context.Add(twilioAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", landlord.IdentityUserId);
            return View(twilioAccount);
        }
    }
}