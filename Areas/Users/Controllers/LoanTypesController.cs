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

namespace LMS.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class LoanTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/LoanTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoanTypes.ToListAsync());
        }

        // GET: Users/LoanTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanType = await _context.LoanTypes
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loanType == null)
            {
                return NotFound();
            }

            return View(loanType);
        }

        // GET: Users/LoanTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/LoanTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,LoanName,Details,MinimumAmount,MaximumAmount,LoanGivenTo,NumberOfGuaranters")] LoanType loanType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loanType);
        }

        // GET: Users/LoanTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanType = await _context.LoanTypes.FindAsync(id);
            if (loanType == null)
            {
                return NotFound();
            }
            return View(loanType);
        }

        // POST: Users/LoanTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,LoanName,Details,MinimumAmount,MaximumAmount,LoanGivenTo,NumberOfGuaranters")] LoanType loanType)
        {
            if (id != loanType.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanTypeExists(loanType.LoanId))
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
            return View(loanType);
        }

        // GET: Users/LoanTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanType = await _context.LoanTypes
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loanType == null)
            {
                return NotFound();
            }

            return View(loanType);
        }

        // POST: Users/LoanTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);
            _context.LoanTypes.Remove(loanType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanTypeExists(int id)
        {
            return _context.LoanTypes.Any(e => e.LoanId == id);
        }
    }
}
