namespace HospitalManagement_UI.ViewModels;

public class PatientDetailsModel
{
    public int PatientInformationID { get; set; }
    public string PatientName { get; set; }
    public int DiseaseID { get; set; }
    public string DiseaseName { get; set; }
    public int Epilepsy { get; set; }
    public List<NCDViewModel> NCDs { get; set; }
    public List<AllergiesViewModel> Allergies { get; set; }
}