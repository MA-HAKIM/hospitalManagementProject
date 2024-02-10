using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_UI.ViewModels
{
    public class NCDViewModel:BaseModel
    {

        public int NCDID { get; set; }
        public string NCDName { get; set; }
        public IList<NCDViewModel> NCDList { get; set; }

        public IList<NCDViewModel> GetNCDDataList()
        {
            NCDList = new List<NCDViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_NCD);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    NCDList = JsonConvert.DeserializeObject<List<NCDViewModel>>(dataObjects);
                }

                response.EnsureSuccessStatusCode();
                return NCDList;
            }
            catch (Exception)
            {
                return NCDList;
                throw;
            }
        }
    }
}
