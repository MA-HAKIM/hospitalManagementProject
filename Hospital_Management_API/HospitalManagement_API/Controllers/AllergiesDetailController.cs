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
using HospitalManagement_API.Interface;

namespace HospitalManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesDetailController : ControllerBase
    {
        private readonly IAllergieDetailsRepository _allergiesDetailsRepository;
        private readonly IMapper _mapper;
        public AllergiesDetailController(IMapper mapper, IAllergieDetailsRepository allergieDetailsRepository)
        {
            _allergiesDetailsRepository = allergieDetailsRepository;
            _mapper = mapper;
        }

        // GET: api/AllergiesDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergies_Details>>> GetAllergiesDetails()
        {
            var allergieDetailsList = await _allergiesDetailsRepository.GetAllergiesDetailList();
            return allergieDetailsList;
        }

        // GET: api/AllergiesDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergies_Details>> GetAllergies_Details(int id)
        {
            var allergies_Details = await _allergiesDetailsRepository.GetAllergiesDetail(id);
            if (allergies_Details == null)
            {
                return NotFound();
            }
            return allergies_Details;
        }

        [HttpGet("GetAllergies_DetailsByPatientId/{id}")]

        public async Task<ActionResult<List<Allergies_Details>>> GetAllergies_DetailsByPatientId(int id)
        {
            var allergies_Details = await _allergiesDetailsRepository.GetAllergiesDetailListByPatientId(id);
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

            await _allergiesDetailsRepository.Update(id, allergies_Details);
            return NoContent();
        }

        // POST: api/AllergiesDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Allergies_Details>> PostAllergies_Details(AllergiesDetailsDTO allergies_Details)
        {
            var allergies = _mapper.Map<Allergies_Details>(allergies_Details);
            if (allergies == null)
            {
                return Problem("Entity set 'HospitalDbContext.AllergiesDetails'  is null.");
            }
            await _allergiesDetailsRepository.Save(allergies);
            return CreatedAtAction("GetAllergies_Details", new { id = allergies.ID }, allergies);
        }

        // DELETE: api/AllergiesDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergies_Details(int id)
        {
            var allergies_Details = await _allergiesDetailsRepository.GetAllergiesDetail(id);
            if (allergies_Details == null)
            {
                return NotFound();
            }
            await _allergiesDetailsRepository.Delete(id);
            return NoContent();
        }
    }
}
