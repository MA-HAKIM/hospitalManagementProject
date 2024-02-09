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
    public class PatientsInformationController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PatientsInformationController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientsInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patients_Information>>> GetPatientInformation()
        {
          if (_context.PatientInformation == null)
          {
              return NotFound();
          }
            return await _context.PatientInformation.ToListAsync();
        }

        // GET: api/PatientsInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patients_Information>> GetPatients_Information(int id)
        {
          if (_context.PatientInformation == null)
          {
              return NotFound();
          }
            var patients_Information = await _context.PatientInformation.FindAsync(id);

            if (patients_Information == null)
            {
                return NotFound();
            }

            return patients_Information;
        }

        // PUT: api/PatientsInformation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatients_Information(int id, Patients_Information patients_Information)
        {
            if (id != patients_Information.PatientID)
            {
                return BadRequest();
            }

            _context.Entry(patients_Information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Patients_InformationExists(id))
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

        // POST: api/PatientsInformation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patients_Information>> PostPatients_Information(Patients_Information patients_Information)
        {
          if (_context.PatientInformation == null)
          {
              return Problem("Entity set 'HospitalDbContext.PatientInformation'  is null.");
          }
            _context.PatientInformation.Add(patients_Information);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatients_Information", new { id = patients_Information.PatientID }, patients_Information);
        }

        // DELETE: api/PatientsInformation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatients_Information(int id)
        {
            if (_context.PatientInformation == null)
            {
                return NotFound();
            }
            var patients_Information = await _context.PatientInformation.FindAsync(id);
            if (patients_Information == null)
            {
                return NotFound();
            }

            _context.PatientInformation.Remove(patients_Information);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Patients_InformationExists(int id)
        {
            return (_context.PatientInformation?.Any(e => e.PatientID == id)).GetValueOrDefault();
        }
    }
}
