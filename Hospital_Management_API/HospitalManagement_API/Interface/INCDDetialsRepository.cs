using HospitalManagement_API.Model;

namespace HospitalManagement_API.Interface
{
    public interface INCDDetialsRepository
    {
        Task<List<NCD_Details>> GetNCDDetailList();
        Task<List<NCD_Details>> GetNCDDetailListByPatientId(int id);
        Task<NCD_Details> GetNDCDetail(int id);
        Task<int> Save(NCD_Details ncdDetail);
        Task<int> Update(int id, NCD_Details ncdDetail);
        Task<int> Delete(int id);
    }
}
