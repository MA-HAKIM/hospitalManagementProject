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

        public async Task<PatientDetailsModel> GetPatient(int id)
        {
            var patients_Information = await _context.PatientInformation
                  .Include(x => x.DiseaseInformation)
                  .Include(x => x.NCD_Details)
                  .Include(x => x.Allergies_Details)
                  .Where(x => x.PatientInformationID == id)
                  .FirstOrDefaultAsync();

            var patientInformation = new PatientDetailsModel();

            var ncdList = await _context.NCD.ToListAsync();
            var allergieList = await _context.Allergies.ToListAsync();
            var patientInfo = new PatientDetailsModel();
            patientInfo.Allergies = new List<Allergies>();
            patientInfo.NCDs = new List<NCD>();

            patientInfo.PatientInformationID = patients_Information.PatientInformationID;
            patientInfo.PatientName = patients_Information.PatientName;
            patientInfo.Epilepsy = patients_Information.Epilepsy;
            patientInfo.DiseaseID = patients_Information.DiseaseInformation.DiseaseID;
            patientInfo.DiseaseName = patients_Information.DiseaseInformation.DiseaseName;
            
            if (patients_Information.NCD_Details.Count > 0)
            {
                foreach (var ncd in patients_Information.NCD_Details)
                {
                    var ncdObj = ncdList.Where(x => x.NCDID == ncd.NCDID).FirstOrDefault();
                    if (ncdObj != null)
                    {
                        patientInfo.NCDs.Add(
                            new NCD
                            {
                                NCDID = ncd.NCDID,
                                NCDName = ncdObj.NCDName
                            }
                        );
                    }

                }
            }

            if (patients_Information.Allergies_Details.Count > 0)
            {

                foreach (var alg in patients_Information.Allergies_Details)
                {
                    var allergieObj = allergieList.Where(x => x.AllergiesID == alg.AllergiesID).FirstOrDefault();
                    if (allergieObj != null)
                    {
                        patientInfo.Allergies.Add(
                            new Allergies
                            {
                                AllergiesID = alg.AllergiesID,
                                AllergiesName = allergieObj.AllergiesName
                            }
                        );
                    }

                }
            }

            if (patientInfo != null)
            {
                return patientInfo;
            }
            return patientInfo;
        }

        public async Task<List<PatientDetailsModel>> GetPatientsList()
        {
            var listOfData = await _context.PatientInformation
                  .Include(x => x.DiseaseInformation)
                  .Include(x => x.NCD_Details)
                  .Include(x => x.Allergies_Details)
                  .ToListAsync();
            var patientList = new List<PatientDetailsModel>();

            foreach (var item in listOfData)
            {
                var ncdList = await _context.NCD.ToListAsync();
                var allergieList = await _context.Allergies.ToListAsync();
                var patientInfo = new PatientDetailsModel();
                patientInfo.Allergies = new List<Allergies>();
                patientInfo.NCDs = new List<NCD>();

                patientInfo.PatientInformationID = item.PatientInformationID;
                patientInfo.PatientName = item.PatientName;
                patientInfo.Epilepsy = item.Epilepsy;
                patientInfo.DiseaseID = item.DiseaseInformation.DiseaseID;
                patientInfo.DiseaseName = item.DiseaseInformation.DiseaseName;
                if (item.NCD_Details.Count > 0)
                {
                    foreach (var ncd in item.NCD_Details)
                    {
                        var ncdObj = ncdList.Where(x => x.NCDID == ncd.NCDID).FirstOrDefault();
                        if (ncdObj != null)
                        {
                            patientInfo.NCDs.Add(
                                new NCD
                                {
                                    NCDID = ncd.NCDID,
                                    NCDName = ncdObj.NCDName
                                }
                            );
                        }

                    }
                }

                if (item.Allergies_Details.Count > 0)
                {

                    foreach (var alg in item.Allergies_Details)
                    {
                        var allergieObj = allergieList.Where(x => x.AllergiesID == alg.AllergiesID).FirstOrDefault();
                        if (allergieObj != null)
                        {
                            patientInfo.Allergies.Add(
                                new Allergies
                                {
                                    AllergiesID = alg.AllergiesID,
                                    AllergiesName = allergieObj.AllergiesName
                                }
                            );
                        }

                    }
                }

                patientList.Add(patientInfo);
            }

            return patientList;
        }

        public async Task<int> Save(PatientInformation patient)
        {
            await _context.PatientInformation.AddAsync(patient);
            await _context.SaveChangesAsync();
            return 0;
        }

        public async Task<int> Update(int id, PatientInformation patient)
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
            var patient = await _context.PatientInformation.Where(x => x.PatientInformationID == id).FirstOrDefaultAsync();
            if (patient != null)
            {
                _context.PatientInformation.Remove(patient);
                await _context.SaveChangesAsync();
            }
            return 0;
        }

        private bool PatientExists(int id)
        {
            return _context.PatientInformation.Any(e => e.PatientInformationID == id);
        }
    }
}
