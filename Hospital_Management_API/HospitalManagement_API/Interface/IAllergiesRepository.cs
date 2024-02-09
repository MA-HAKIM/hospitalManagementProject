using HospitalManagement_API.Model;

namespace HospitalManagement_API.Interface
{
    public interface IAllergiesRepository
    {
        Task<List<Allergies_Details>> GetAllergiesDetailList();
        Task<Allergies_Details> GetAllergiesDetail(int id);
        Task<int> Save(Allergies_Details allergiesDetail);
        Task<int> Update(int id, Allergies_Details allergiesDetail);
        Task<int> Delete(int id);
    }
}
