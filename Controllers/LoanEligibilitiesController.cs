using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using LMS.Models;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanEligibilitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoanEligibilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanEligibilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanEligibility>>> GetLoanEligibility()
        {
            return await _context.LoanEligibility.ToListAsync();
        }

        // GET: api/LoanEligibilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanEligibility>> GetLoanEligibility(int id)
        {
            var loanEligibility = await _context.LoanEligibility.FindAsync(id);

            if (loanEligibility == null)
            {
                return NotFound();
            }

            return loanEligibility;
        }

        // PUT: api/LoanEligibilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanEligibility(int id, LoanEligibility loanEligibility)
        {
            if (id != loanEligibility.LoanEligibilityId)
            {
                return BadRequest();
            }

            _context.Entry(loanEligibility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanEligibilityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanEligibilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoanEligibility>> PostLoanEligibility(LoanEligibility loanEligibility)
        {
            _context.LoanEligibility.Add(loanEligibility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanEligibility", new { id = loanEligibility.LoanEligibilityId }, loanEligibility);
        }

        // DELETE: api/LoanEligibilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanEligibility>> DeleteLoanEligibility(int id)
        {
            var loanEligibility = await _context.LoanEligibility.FindAsync(id);
            if (loanEligibility == null)
            {
                return NotFound();
            }

            _context.LoanEligibility.Remove(loanEligibility);
            await _context.SaveChangesAsync();

            return loanEligibility;
        }

        private bool LoanEligibilityExists(int id)
        {
            return _context.LoanEligibility.Any(e => e.LoanEligibilityId == id);
        }
    }
}
