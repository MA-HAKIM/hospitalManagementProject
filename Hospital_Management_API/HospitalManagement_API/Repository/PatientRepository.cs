using HospitalManagement_API.DataContext;
using HospitalManagement_API.Interface;
using HospitalManagement_API.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement_API.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Patients_Information> GetPatient(int id)
        {
            var patient = await _context.PatientInformation.Where(x => x.PatientID == id).FirstOrDefaultAsync();
            if (patient != null)
            {
                return patient;
            }
            return patient;
        }

        public async Task<List<Patients_Information>> GetPatientsList()
        {
            return await _context.PatientInformation.ToListAsync();
        }

        public async Task<int> Save(Patients_Information patient)
        {
            await _context.PatientInformation.AddAsync(patient);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> Update(int id, Patients_Information patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    throw;
                }
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            var patient = await _context.PatientInformation.Where(x => x.PatientID == id).FirstOrDefaultAsync();
            if (patient != null)
            {
                _context.PatientInformation.Remove(patient);
                await _context.SaveChangesAsync();
            }
            return 0;
        }

        private bool PatientExists(int id)
        {
            return _context.PatientInformation.Any(e => e.PatientID == id);
        }
    }
}
