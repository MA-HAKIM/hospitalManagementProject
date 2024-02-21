using HospitalManagement_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_API.DTO;

public class PatientDTO
{

    public int PatientInformationID { get; set; }
    public string PatientName { get; set; }
    public Epilepsy Epilepsy { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? ContactNo { get; set; }
    public int DiseaseId { get; set; }
}
