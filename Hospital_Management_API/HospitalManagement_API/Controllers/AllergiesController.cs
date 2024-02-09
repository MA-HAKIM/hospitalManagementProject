using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagement_API.DataContext;
using HospitalManagement_API.Model;

namespace HospitalManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public AllergiesController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Allergies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergies>>> GetAllergies()
        {
          if (_context.Allergies == null)
          {
              return NotFound();
          }
            return await _context.Allergies.ToListAsync();
        }

        // GET: api/Allergies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergies>> GetAllergies(int id)
        {
          if (_context.Allergies == null)
          {
              return NotFound();
          }
            var allergies = await _context.Allergies.FindAsync(id);

            if (allergies == null)
            {
                return NotFound();
            }

            return allergies;
        }

        // PUT: api/Allergies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllergies(int id, Allergies allergies)
        {
            if (id != allergies.AllergiesID)
            {
                return BadRequest();
            }

            _context.Entry(allergies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergiesExists(id))
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

        // POST: api/Allergies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Allergies>> PostAllergies(Allergies allergies)
        {
          if (_context.Allergies == null)
          {
              return Problem("Entity set 'HospitalDbContext.Allergies'  is null.");
          }
            _context.Allergies.Add(allergies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllergies", new { id = allergies.AllergiesID }, allergies);
        }

        // DELETE: api/Allergies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergies(int id)
        {
            if (_context.Allergies == null)
            {
                return NotFound();
            }
            var allergies = await _context.Allergies.FindAsync(id);
            if (allergies == null)
            {
                return NotFound();
            }

            _context.Allergies.Remove(allergies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllergiesExists(int id)
        {
            return (_context.Allergies?.Any(e => e.AllergiesID == id)).GetValueOrDefault();
        }
    }
}
