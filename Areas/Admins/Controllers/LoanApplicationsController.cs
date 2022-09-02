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
    public class LoanApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admins/LoanApplications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LoanApplication.Include(l => l.LoanType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admins/LoanApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanApplication = await _context.LoanApplication
                .Include(l => l.LoanType)
                .FirstOrDefaultAsync(m => m.LoanApplicationId == id);
            if (loanApplication == null)
            {
                return NotFound();
            }

            return View(loanApplication);
        }

        // GET: Admins/LoanApplications/Create
        public IActionResult Create()
        {
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "Details");
            return View();
        }

        // POST: Admins/LoanApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanApplicationId,ApplicationHolderName,AccountNumber,ApplicationHolderEmail,IfscCode,LoanAmount,LoanId")] LoanApplication loanApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "Details", loanApplication.LoanId);
            return View(loanApplication);
        }

        // GET: Admins/LoanApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanApplication = await _context.LoanApplication.FindAsync(id);
            if (loanApplication == null)
            {
                return NotFound();
            }
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "Details", loanApplication.LoanId);
            return View(loanApplication);
        }

        // POST: Admins/LoanApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanApplicationId,ApplicationHolderName,AccountNumber,ApplicationHolderEmail,IfscCode,LoanAmount,LoanId")] LoanApplication loanApplication)
        {
            if (id != loanApplication.LoanApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanApplicationExists(loanApplication.LoanApplicationId))
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
            ViewData["LoanId"] = new SelectList(_context.LoanTypes, "LoanId", "Details", loanApplication.LoanId);
            return View(loanApplication);
        }

        // GET: Admins/LoanApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanApplication = await _context.LoanApplication
                .Include(l => l.LoanType)
                .FirstOrDefaultAsync(m => m.LoanApplicationId == id);
            if (loanApplication == null)
            {
                return NotFound();
            }

            return View(loanApplication);
        }

        // POST: Admins/LoanApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanApplication = await _context.LoanApplication.FindAsync(id);
            _context.LoanApplication.Remove(loanApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanApplicationExists(int id)
        {
            return _context.LoanApplication.Any(e => e.LoanApplicationId == id);
        }
    }
}
