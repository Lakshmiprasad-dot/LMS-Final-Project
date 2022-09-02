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
    public class RateOfInterestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RateOfInterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RateOfInterests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateOfInterest>>> GetRateOfInterests()
        {
            return await _context.RateOfInterests.ToListAsync();
        }

        // GET: api/RateOfInterests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateOfInterest>> GetRateOfInterest(int id)
        {
            var rateOfInterest = await _context.RateOfInterests.FindAsync(id);

            if (rateOfInterest == null)
            {
                return NotFound();
            }

            return rateOfInterest;
        }

        // PUT: api/RateOfInterests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRateOfInterest(int id, RateOfInterest rateOfInterest)
        {
            if (id != rateOfInterest.RateOfInterestId)
            {
                return BadRequest();
            }

            _context.Entry(rateOfInterest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateOfInterestExists(id))
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

        // POST: api/RateOfInterests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RateOfInterest>> PostRateOfInterest(RateOfInterest rateOfInterest)
        {
            _context.RateOfInterests.Add(rateOfInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRateOfInterest", new { id = rateOfInterest.RateOfInterestId }, rateOfInterest);
        }

        // DELETE: api/RateOfInterests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RateOfInterest>> DeleteRateOfInterest(int id)
        {
            var rateOfInterest = await _context.RateOfInterests.FindAsync(id);
            if (rateOfInterest == null)
            {
                return NotFound();
            }

            _context.RateOfInterests.Remove(rateOfInterest);
            await _context.SaveChangesAsync();

            return rateOfInterest;
        }

        private bool RateOfInterestExists(int id)
        {
            return _context.RateOfInterests.Any(e => e.RateOfInterestId == id);
        }
    }
}
