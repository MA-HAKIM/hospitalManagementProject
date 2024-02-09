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
    public class AllergiesDetailController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public AllergiesDetailController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/AllergiesDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergies_Details>>> GetAllergiesDetails()
        {
          if (_context.AllergiesDetails == null)
          {
              return NotFound();
          }
            return await _context.AllergiesDetails.ToListAsync();
        }

        // GET: api/AllergiesDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergies_Details>> GetAllergies_Details(int id)
        {
          if (_context.AllergiesDetails == null)
          {
              return NotFound();
          }
            var allergies_Details = await _context.AllergiesDetails.FindAsync(id);

            if (allergies_Details == null)
            {
                return NotFound();
            }

            return allergies_Details;
        }

        // PUT: api/AllergiesDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllergies_Details(int id, Allergies_Details allergies_Details)
        {
            if (id != allergies_Details.ID)
            {
                return BadRequest();
            }

            _context.Entry(allergies_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Allergies_DetailsExists(id))
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

        // POST: api/AllergiesDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Allergies_Details>> PostAllergies_Details(Allergies_Details allergies_Details)
        {
          if (_context.AllergiesDetails == null)
          {
              return Problem("Entity set 'HospitalDbContext.AllergiesDetails'  is null.");
          }
            _context.AllergiesDetails.Add(allergies_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllergies_Details", new { id = allergies_Details.ID }, allergies_Details);
        }

        // DELETE: api/AllergiesDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergies_Details(int id)
        {
            if (_context.AllergiesDetails == null)
            {
                return NotFound();
            }
            var allergies_Details = await _context.AllergiesDetails.FindAsync(id);
            if (allergies_Details == null)
            {
                return NotFound();
            }

            _context.AllergiesDetails.Remove(allergies_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Allergies_DetailsExists(int id)
        {
            return (_context.AllergiesDetails?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
