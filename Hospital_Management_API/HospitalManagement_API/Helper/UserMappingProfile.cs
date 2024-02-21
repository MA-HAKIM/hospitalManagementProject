using AutoMapper;
using HospitalManagement_API.DTO;
using HospitalManagement_API.Model;

namespace HospitalManagement_API.Helper;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<PatientInformation, PatientDTO>().ReverseMap();
        CreateMap<NCD_Details, NCDDetailsDTO>().ReverseMap();
        CreateMap<Allergies_Details, AllergiesDetailsDTO>().ReverseMap();
    }
}
