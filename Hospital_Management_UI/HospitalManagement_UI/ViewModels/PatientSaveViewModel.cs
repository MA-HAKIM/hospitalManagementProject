namespace HospitalManagement_UI.ViewModels
{
    public class PatientSaveViewModel
    {
        public int PatientInformationID { get; set; }
        public string PatientName { get; set; }
        public int DiseaseID { get; set; }
        public int Epilepsy { get; set; }
        public List<int>? NCDList { get; set; }
        public List<int>? AllergiesList { get; set; }
    }
}
