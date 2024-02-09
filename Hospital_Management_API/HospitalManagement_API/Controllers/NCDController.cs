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
    public class NCDController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public NCDController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/NCD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCD>>> GetNCD()
        {
          if (_context.NCD == null)
          {
              return NotFound();
          }
            return await _context.NCD.ToListAsync();
        }

        // GET: api/NCD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NCD>> GetNCD(int id)
        {
          if (_context.NCD == null)
          {
              return NotFound();
          }
            var nCD = await _context.NCD.FindAsync(id);

            if (nCD == null)
            {
                return NotFound();
            }

            return nCD;
        }

        // PUT: api/NCD/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCD(int id, NCD nCD)
        {
            if (id != nCD.NCDID)
            {
                return BadRequest();
            }

            _context.Entry(nCD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCDExists(id))
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

        // POST: api/NCD
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NCD>> PostNCD(NCD nCD)
        {
          if (_context.NCD == null)
          {
              return Problem("Entity set 'HospitalDbContext.NCD'  is null.");
          }
            _context.NCD.Add(nCD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNCD", new { id = nCD.NCDID }, nCD);
        }

        // DELETE: api/NCD/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCD(int id)
        {
            if (_context.NCD == null)
            {
                return NotFound();
            }
            var nCD = await _context.NCD.FindAsync(id);
            if (nCD == null)
            {
                return NotFound();
            }

            _context.NCD.Remove(nCD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NCDExists(int id)
        {
            return (_context.NCD?.Any(e => e.NCDID == id)).GetValueOrDefault();
        }
    }
}
