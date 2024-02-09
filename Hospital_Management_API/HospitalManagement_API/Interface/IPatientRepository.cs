using HospitalManagement_API.Model;

namespace HospitalManagement_API.Interface
{
    public interface IPatientRepository
    {
        Task<List<Patients_Information>> GetPatientsList();
        Task<Patients_Information> GetPatient(int id);
        Task<int> Save(Patients_Information patient);
        Task<int> Update(int id, Patients_Information patient);
        Task<int> Delete(int id);
    }
}
