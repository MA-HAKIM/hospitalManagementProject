using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_UI.ViewModels
{
    public class DiseaseViewModel:BaseModel
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public IList<DiseaseViewModel> DiseaseList { get; set; }

        public IList<DiseaseViewModel> GetDiseaseDataList()
        {
            DiseaseList = new List<DiseaseViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_Disease);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<DiseaseViewModel>>().Result;
                    DiseaseList = (IList<DiseaseViewModel>)dataObjects.ToList();
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
