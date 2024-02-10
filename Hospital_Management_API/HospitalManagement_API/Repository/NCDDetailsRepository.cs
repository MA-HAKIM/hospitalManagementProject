using HospitalManagement_API.DataContext;
using HospitalManagement_API.Interface;
using HospitalManagement_API.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement_API.Repository
{
    public class NCDDetailsRepository : INCDDetialsRepository
    {
        private readonly HospitalDbContext _context;

        public NCDDetailsRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<List<NCD_Details>> GetNCDDetailList()
        {
            return await _context.NCDDetails.ToListAsync();
        }

        public async Task<NCD_Details> GetNDCDetail(int id)
        {
            var ncdDetail = await _context.NCDDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (ncdDetail != null)
            {
                return ncdDetail;
            }
            return ncdDetail;
        }

        public async Task<int> Save(NCD_Details ncdDetail)
        {
            await _context.NCDDetails.AddAsync(ncdDetail);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> Update(int id, NCD_Details ncdDetail)
        {
            _context.Entry(ncdDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCDDetialsExists(id))
                {
                    throw;
                }
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            var ncdDetail = await _context.NCDDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (ncdDetail != null)
            {
                _context.NCDDetails.Remove(ncdDetail);
                await _context.SaveChangesAsync();
            }
            return 0;
        }

        private bool NCDDetialsExists(int id)
        {
            return _context.NCDDetails.Any(e => e.ID == id);
        }

        public async Task<List<NCD_Details>> GetNCDDetailListByPatientId(int id)
        {
            var ncds = await _context.NCDDetails.Where(x=>x.PatientInformationID == id).ToListAsync();
            if(ncds != null)
            {
                return ncds;
            }
            return ncds;
        }
    }
}
