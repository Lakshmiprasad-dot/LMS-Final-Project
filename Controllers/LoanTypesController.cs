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
    // API
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoanTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanType>>> GetLoanTypes()
        {
            return await _context.LoanTypes.ToListAsync();
        }

        // GET: api/LoanTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanType>> GetLoanType(int id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);

            if (loanType == null)
            {
                return NotFound();
            }

            return loanType;
        }

        // PUT: api/LoanTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanType(int id, LoanType loanType)
        {
            if (id != loanType.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(loanType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanTypeExists(id))
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

        // POST: api/LoanTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoanType>> PostLoanType(LoanType loanType)
        {
            _context.LoanTypes.Add(loanType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanType", new { id = loanType.LoanId }, loanType);
        }

        // DELETE: api/LoanTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanType>> DeleteLoanType(int id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);
            if (loanType == null)
            {
                return NotFound();
            }

            _context.LoanTypes.Remove(loanType);
            await _context.SaveChangesAsync();

            return loanType;
        }

        private bool LoanTypeExists(int id)
        {
            return _context.LoanTypes.Any(e => e.LoanId == id);
        }
    }
}
