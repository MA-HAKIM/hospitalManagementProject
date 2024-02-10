using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HospitalManagement_UI.ViewModels
{
    public class DiseaseViewModel:BaseModel
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public IList<DiseaseViewModel> DiseaseList { get; set; }
        public List<PatientViewModel> Patients { get; set; } // Navigation property
        public IList<DiseaseViewModel> GetDiseaseDataList()
        {
            DiseaseList = new List<DiseaseViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_Disease);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    DiseaseList = JsonConvert.DeserializeObject<List<DiseaseViewModel>>(dataObjects);
                }

                response.EnsureSuccessStatusCode();
                return DiseaseList;
            }
            catch (Exception)
            {
                return DiseaseList;
                throw;
            }
        }
    }


}
