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
    public class NCDDetailController : ControllerBase
    {
        private readonly INCDDetialsRepository _ncdDetialsRepository;
        private readonly IMapper _mapper;

        public NCDDetailController(INCDDetialsRepository nCDDetialsRepository, IMapper mapper)
        {
            _ncdDetialsRepository = nCDDetialsRepository;
            _mapper = mapper;
        }

        // GET: api/NCDDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCD_Details>>> GetNCDDetails()
        {
            var ncdDetailsList = await _ncdDetialsRepository.GetNCDDetailList();
            return ncdDetailsList;
        }

        // GET: api/NCDDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NCD_Details>> GetNCD_Details(int id)
        {
            var nCD_Details = await _ncdDetialsRepository.GetNDCDetail(id);
            if (nCD_Details == null)
            {
                return NotFound();
            }
            
            return nCD_Details;
        }

        [HttpGet("GetNCD_DetailsListByPatientId/{id}")]
        public async Task<ActionResult<List<NCD_Details>>> GetNCD_DetailsListByPatientId(int id)
        {
            var nCD_Details = await _ncdDetialsRepository.GetNCDDetailListByPatientId(id);
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

            await _ncdDetialsRepository.Update(id, nCD_Details);

            return NoContent();
        }

        // POST: api/NCDDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NCD_Details>> PostNCD_Details(NCDDetailsDTO nCD_Details)
        {
            var ncdDetails = _mapper.Map<NCD_Details>(nCD_Details);
            if (ncdDetails == null)
            {
                return Problem("Entity set 'HospitalDbContext.NCDDetails'  is null.");
            }
            await _ncdDetialsRepository.Save(ncdDetails);
            return CreatedAtAction("GetNCD_Details", new { id = ncdDetails.ID }, ncdDetails);
        }

        // DELETE: api/NCDDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCD_Details(int id)
        {
            var nCD_Details = await _ncdDetialsRepository.GetNDCDetail(id);
            if (nCD_Details == null)
            {
                return NotFound();
            }
            await _ncdDetialsRepository.Delete(id);
            return NoContent();
        }

    }
}
