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
    public class NCDDetailController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public NCDDetailController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/NCDDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCD_Details>>> GetNCDDetails()
        {
          if (_context.NCDDetails == null)
          {
              return NotFound();
          }
            return await _context.NCDDetails.ToListAsync();
        }

        // GET: api/NCDDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NCD_Details>> GetNCD_Details(int id)
        {
          if (_context.NCDDetails == null)
          {
              return NotFound();
          }
            var nCD_Details = await _context.NCDDetails.FindAsync(id);

            if (nCD_Details == null)
            {
                return NotFound();
            }

            return nCD_Details;
        }

        // PUT: api/NCDDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCD_Details(int id, NCD_Details nCD_Details)
        {
            if (id != nCD_Details.ID)
            {
                return BadRequest();
            }

            _context.Entry(nCD_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCD_DetailsExists(id))
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

        // POST: api/NCDDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NCD_Details>> PostNCD_Details(NCD_Details nCD_Details)
        {
          if (_context.NCDDetails == null)
          {
              return Problem("Entity set 'HospitalDbContext.NCDDetails'  is null.");
          }
            _context.NCDDetails.Add(nCD_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNCD_Details", new { id = nCD_Details.ID }, nCD_Details);
        }

        // DELETE: api/NCDDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCD_Details(int id)
        {
            if (_context.NCDDetails == null)
            {
                return NotFound();
            }
            var nCD_Details = await _context.NCDDetails.FindAsync(id);
            if (nCD_Details == null)
            {
                return NotFound();
            }

            _context.NCDDetails.Remove(nCD_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NCD_DetailsExists(int id)
        {
            return (_context.NCDDetails?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
