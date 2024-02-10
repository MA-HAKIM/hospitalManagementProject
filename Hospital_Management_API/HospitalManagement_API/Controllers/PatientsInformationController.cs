using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagement_API.DataContext;
using HospitalManagement_API.Model;
using HospitalManagement_API.DTO;
using AutoMapper;
using Humanizer;
using HospitalManagement_API.Interface;

namespace HospitalManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsInformationController : ControllerBase
    {
        private readonly IPatientRepository _patientRepo;
        private readonly IMapper _mapper;

        public PatientsInformationController(IMapper mapper, IPatientRepository patientRepository)
        {
            _patientRepo = patientRepository;
            _mapper = mapper;
        }

        // GET: api/PatientsInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDetailsModel>>> GetPatientInformation()
        {
            var patientList = await _patientRepo.GetPatientsList();
            return patientList;
        }

        // GET: api/PatientsInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailsModel>> GetPatients_Information(int id)
        {
            var patientInfo = await _patientRepo.GetPatient(id);
            if (patientInfo == null)
            {
                return NotFound();
            }
            return patientInfo;
        }

        // PUT: api/PatientsInformation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatients_Information(int id, PatientDTO patients_Information)
        {
            var patient = _mapper.Map<PatientInformation>(patients_Information);
            if (id != patient.PatientInformationID)
            {
                return BadRequest();
            }
            await _patientRepo.Update(id, patient);
            
            return CreatedAtAction("GetPatients_Information", new { id = patient.PatientInformationID }, patient);
        }

        // POST: api/PatientsInformation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientInformation>> PostPatients_Information(PatientDTO patients_Information)
        {
            var patient = _mapper.Map<PatientInformation>(patients_Information);
            if (patient == null)
            {
                return Problem("Entity set 'HospitalDbContext.PatientInformation'  is null.");
            }

            await _patientRepo.Save(patient);

            return CreatedAtAction("GetPatients_Information", new { id = patient.PatientInformationID }, patient);
        }

        // DELETE: api/PatientsInformation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatients_Information(int id)
        {
            var patients_Information = await _patientRepo.GetPatient(id);
            if (patients_Information == null)
            {
                return NotFound();
            }
            await _patientRepo.Delete(id);
            return NoContent();
        }

    }
}
