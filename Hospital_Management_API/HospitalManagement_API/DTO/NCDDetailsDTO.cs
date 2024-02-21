using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagement_API.DTO;

public class NCDDetailsDTO
{
    public int ID { get; set; }
    public int PatientInformationID { get; set; }
    public int NCDID { get; set; }
}
