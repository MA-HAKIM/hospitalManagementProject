namespace HospitalManagement_API.Model;

public class PatientDetailsModel
{
    public int PatientInformationID { get; set; } 
    public string PatientName { get; set; }
    public int DiseaseID { get; set; }
    public string DiseaseName { get; set; }
    public Epilepsy Epilepsy { get; set; }
    public List<NCD> NCDs { get; set; }
    public List<Allergies> Allergies { get; set; }

}
