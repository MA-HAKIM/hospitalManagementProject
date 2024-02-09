using System.Net.Http.Headers;

namespace HospitalManagement_UI.ViewModels
{
    public class BaseModel
    {

        //---------------------------------------------------------------------
        public string Api_Address = "http://localhost:5117/";
        public string ApiController_PatientsInfo = "api/PatientsInformation";
        public string ApiController_NCDDetails = "api/NCDDetail";
        public string ApiController_AllergiesDetails = "api/AllergiesDetail";
        public string ApiController_Allergies = "api/Allergies";
        public string ApiController_NCD = "api/NCD";
        public string ApiController_Disease = "api/DiseaseInformation";

        //------------------------------------------------------------------------
        private HttpClient GetClient(string baseAddress)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public HttpResponseMessage GetResponse(string baseAddress, string subUrl)
        {
            var response = GetClient(baseAddress).GetAsync(subUrl).Result;
            return response;
        }
        public Task<HttpResponseMessage> PostResponse(string baseAddress, string subUrl, object obj)
        {
            var response = GetClient(baseAddress).PostAsJsonAsync(subUrl, obj);
            return response;
        }
        public Task<HttpResponseMessage> PutResponse(string baseAddress, string subUrl, string id, object obj)
        {
            var response = GetClient(baseAddress).PutAsJsonAsync(subUrl + "/" + id, obj);
            return response;
        }
        public HttpResponseMessage DeleteResponse(string baseAddress, string subUrl, string id)
        {
            var response = GetClient(baseAddress).DeleteAsync(subUrl + "/" + id).Result;
            return response;
        }
    }
}
