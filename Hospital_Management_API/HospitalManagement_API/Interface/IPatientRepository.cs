using HospitalManagement_API.Model;

namespace HospitalManagement_API.Interface
{
    public interface IPatientRepository
    {
        Task<List<PatientDetailsModel>> GetPatientsList();
        Task<PatientDetailsModel> GetPatient(int id);
        Task<int> Save(PatientInformation patient);
        Task<int> Update(int id, PatientInformation patient);
        Task<int> Delete(int id);
    }
}
