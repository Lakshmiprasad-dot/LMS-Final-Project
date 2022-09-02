using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace LMS.Areas.Admins.Controllers
{
    [Area("Admins")]
    [Authorize(Roles = "AppAdmin")]

    public class ApplicationStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admins/ApplicationStatus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationStatus.Include(a => a.LoanApplication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admins/ApplicationStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatus
                .Include(a => a.LoanApplication)
                .FirstOrDefaultAsync(m => m.AplicationStatusId == id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            return View(applicationStatus);
        }

        // GET: Admins/ApplicationStatus/Create
        public IActionResult Create()
        {
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName");
            return View();
        }

        // POST: Admins/ApplicationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AplicationStatusId,ApplicationID,Status,LoanApplicationId")] ApplicationStatus applicationStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName", applicationStatus.LoanApplicationId);
            return View(applicationStatus);
        }

        // GET: Admins/ApplicationStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatus.FindAsync(id);
            if (applicationStatus == null)
            {
                return NotFound();
            }
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName", applicationStatus.LoanApplicationId);
            return View(applicationStatus);
        }

        // POST: Admins/ApplicationStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AplicationStatusId,ApplicationID,Status,LoanApplicationId")] ApplicationStatus applicationStatus)
        {
            if (id != applicationStatus.AplicationStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationStatusExists(applicationStatus.AplicationStatusId))
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
            ViewData["LoanApplicationId"] = new SelectList(_context.LoanApplication, "LoanApplicationId", "ApplicationHolderName", applicationStatus.LoanApplicationId);
            return View(applicationStatus);
        }

        // GET: Admins/ApplicationStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatus
                .Include(a => a.LoanApplication)
                .FirstOrDefaultAsync(m => m.AplicationStatusId == id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            return View(applicationStatus);
        }

        // POST: Admins/ApplicationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationStatus = await _context.ApplicationStatus.FindAsync(id);
            _context.ApplicationStatus.Remove(applicationStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationStatusExists(int id)
        {
            return _context.ApplicationStatus.Any(e => e.AplicationStatusId == id);
        }
    }
}
