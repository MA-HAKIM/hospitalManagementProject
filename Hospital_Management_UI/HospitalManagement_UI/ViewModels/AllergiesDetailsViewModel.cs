using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace HospitalManagement_UI.ViewModels
{
    public class AllergiesDetailsViewModel:BaseModel
    {
        public int ID { get; set; }
        public int PatientInformationID { get; set; }
        public int AllergiesID { get; set; }
        public AllergiesDetailsViewModel AllergiesDetail { get; set; }
        public IList<AllergiesDetailsViewModel> AllergiesDetailList { get; set; }

        public PatientViewModel PatientInformation { get; set; } // Navigation property

        public IList<AllergiesDetailsViewModel> GetAllergiesDetailList()
        {
            AllergiesDetailList = new List<AllergiesDetailsViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_AllergiesDetails);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<AllergiesDetailsViewModel>>().Result;
                    AllergiesDetailList = (IList<AllergiesDetailsViewModel>)dataObjects.ToList();
                }

                response.EnsureSuccessStatusCode();
                return AllergiesDetailList;
            }
            catch (Exception)
            {
                return AllergiesDetailList;
                throw;
            }
        }

        public IList<AllergiesDetailsViewModel> GetAllergiesDetailListByPatientId(int id)
        {
            AllergiesDetailList = new List<AllergiesDetailsViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_AllergiesDetails + "/GetAllergies_DetailsByPatientId/" + id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    AllergiesDetailList = JsonConvert.DeserializeObject<List<AllergiesDetailsViewModel>>(dataObjects);
                }

                response.EnsureSuccessStatusCode();
                return AllergiesDetailList;
            }
            catch (Exception)
            {
                return AllergiesDetailList;
                throw;
            }
        }

        public AllergiesDetailsViewModel GetSingleAllergiesDetail(int Allergies_detail_id)
        {
            AllergiesDetail = new AllergiesDetailsViewModel();
            //var customerAddress = new CustomerAddressVM();
            //CustomerAddresses = new List<CustomerAddressVM>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_AllergiesDetails + "/" + Allergies_detail_id.ToString());

                if (response.IsSuccessStatusCode)
                {

                    var dataObjects = response.Content.ReadFromJsonAsync<AllergiesDetailsViewModel>().Result;
                    AllergiesDetail = dataObjects;
                    //var addressListlist = customerAddress.GetCustomerAddressList().Where(x => x.CustomerId == AllergiesDetail.CustomerId).ToList();
                    //foreach (var address in addressListlist)
                    //{
                    //CustomerAddresses.Add(address);

                    //}
                }
                //AllergiesDetail.CustomerAddresses = CustomerAddresses;
                response.EnsureSuccessStatusCode();
                return AllergiesDetail;
            }
            catch (Exception)
            {
                return AllergiesDetail;
                throw;
            }
        }
        public async Task<int> AddSingleAllergiesDetail(AllergiesDetailsViewModel Allergies_detail)
        {
            try
            {
                
                if (Allergies_detail != null)
                {
                    HttpResponseMessage response = await PostResponse(Api_Address, ApiController_AllergiesDetails, Allergies_detail);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        AllergiesDetailsViewModel responseModel = JsonConvert.DeserializeObject<AllergiesDetailsViewModel>(responseBody);
                        int id = responseModel.ID;
                        return id;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                return 0;
                
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> EditSingleAllergiesDetail(AllergiesDetailsViewModel allergies_detail)
        {
            try
            {
                if (allergies_detail != null)
                {
                    HttpResponseMessage response = await PutResponse(Api_Address, ApiController_AllergiesDetails, allergies_detail.ID.ToString(), allergies_detail);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        AllergiesDetailsViewModel responseModel = JsonConvert.DeserializeObject<AllergiesDetailsViewModel>(responseBody);
                        int id = responseModel.ID;
                        return id;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                return 0;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteSingleAllergiesDetail(int id)
        {
            try
            {
                HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_AllergiesDetails, id.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
