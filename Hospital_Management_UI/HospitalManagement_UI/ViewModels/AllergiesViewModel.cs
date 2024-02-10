using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_UI.ViewModels
{
    public class AllergiesViewModel:BaseModel
    {
        public int AllergiesID { get; set; }
        public string AllergiesName { get; set; }
        public IList<AllergiesViewModel> AllergiesList { get; set; }

        public IList<AllergiesViewModel> GetAllergiesDataList()
        {
            AllergiesList = new List<AllergiesViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_Allergies);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    AllergiesList = JsonConvert.DeserializeObject<List<AllergiesViewModel>>(dataObjects);
                }

                response.EnsureSuccessStatusCode();
                return AllergiesList;
            }
            catch (Exception)
            {
                return AllergiesList;
                throw;
            }
        }
        
    }
}
