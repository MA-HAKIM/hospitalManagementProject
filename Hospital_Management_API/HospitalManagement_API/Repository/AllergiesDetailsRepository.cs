using HospitalManagement_API.DataContext;
using HospitalManagement_API.Interface;
using HospitalManagement_API.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement_API.Repository
{
    public class AllergiesDetailsRepository : IAllergiesRepository
    {
        private readonly HospitalDbContext _context;

        public AllergiesDetailsRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<Allergies_Details> GetAllergiesDetail(int id)
        {
            var allDetail = await _context.AllergiesDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (allDetail != null)
            {
                return allDetail;
            }
            return allDetail;
        }

        public async Task<List<Allergies_Details>> GetAllergiesDetailList()
        {
            return await _context.AllergiesDetails.ToListAsync();
        }

        public async Task<int> Save(Allergies_Details allergiesDetail)
        {
            await _context.AllergiesDetails.AddAsync(allergiesDetail);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> Update(int id, Allergies_Details allergiesDetail)
        {
            _context.Entry(allergiesDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergiesDetialsExists(id))
                {
                    throw;
                }
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            var allDetail = await _context.AllergiesDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (allDetail != null)
            {
                _context.AllergiesDetails.Remove(allDetail);
                await _context.SaveChangesAsync();
            }
            return 0;
        }

        private bool AllergiesDetialsExists(int id)
        {
            return _context.AllergiesDetails.Any(e => e.ID == id);
        }
    }
}
