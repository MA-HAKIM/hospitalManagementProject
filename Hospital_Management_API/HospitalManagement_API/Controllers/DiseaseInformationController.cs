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
    public class DiseaseInformationController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public DiseaseInformationController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/DiseaseInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseInformation>>> GetDiseaseInformation()
        {
          if (_context.DiseaseInformation == null)
          {
              return NotFound();
          }
            return await _context.DiseaseInformation.ToListAsync();
        }

        // GET: api/DiseaseInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseInformation>> GetDiseaseInformation(int id)
        {
          if (_context.DiseaseInformation == null)
          {
              return NotFound();
          }
            var diseaseInformation = await _context.DiseaseInformation.FindAsync(id);

            if (diseaseInformation == null)
            {
                return NotFound();
            }

            return diseaseInformation;
        }

        // PUT: api/DiseaseInformation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiseaseInformation(int id, DiseaseInformation diseaseInformation)
        {
            if (id != diseaseInformation.DiseaseID)
            {
                return BadRequest();
            }

            _context.Entry(diseaseInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiseaseInformationExists(id))
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

        // POST: api/DiseaseInformation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiseaseInformation>> PostDiseaseInformation(DiseaseInformation diseaseInformation)
        {
          if (_context.DiseaseInformation == null)
          {
              return Problem("Entity set 'HospitalDbContext.DiseaseInformation'  is null.");
          }
            _context.DiseaseInformation.Add(diseaseInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiseaseInformation", new { id = diseaseInformation.DiseaseID }, diseaseInformation);
        }

        // DELETE: api/DiseaseInformation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiseaseInformation(int id)
        {
            if (_context.DiseaseInformation == null)
            {
                return NotFound();
            }
            var diseaseInformation = await _context.DiseaseInformation.FindAsync(id);
            if (diseaseInformation == null)
            {
                return NotFound();
            }

            _context.DiseaseInformation.Remove(diseaseInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiseaseInformationExists(int id)
        {
            return (_context.DiseaseInformation?.Any(e => e.DiseaseID == id)).GetValueOrDefault();
        }
    }
}
