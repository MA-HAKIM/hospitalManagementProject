using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagement_UI.ViewModels
{
    public class NCDDetailsViewModel:BaseModel
    {
        public int ID { get; set; }
        public int PatientInformationID { get; set; }
        public int NCDID { get; set; }
        public NCDDetailsViewModel NCDDetail { get; set; }
        public IList<NCDDetailsViewModel> NCDDetailList { get; set; }
        public PatientViewModel PatientInformation { get; set; } // Navigation property

        public IList<NCDDetailsViewModel> GetNCDDetailList()
        {
            NCDDetailList = new List<NCDDetailsViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_NCDDetails);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<NCDDetailsViewModel>>().Result;
                    NCDDetailList = (IList<NCDDetailsViewModel>)dataObjects.ToList();
                }

                response.EnsureSuccessStatusCode();
                return NCDDetailList;
            }
            catch (Exception)
            {
                return NCDDetailList;
                throw;
            }
        }

        public IList<NCDDetailsViewModel> GetNCDDetailListByPatientId(int id)
        {
            NCDDetailList = new List<NCDDetailsViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_NCDDetails + "/GetNCD_DetailsListByPatientId/" + id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    NCDDetailList = JsonConvert.DeserializeObject<List<NCDDetailsViewModel>>(dataObjects);
                }

                response.EnsureSuccessStatusCode();
                return NCDDetailList;
            }
            catch (Exception)
            {
                return NCDDetailList;
                throw;
            }
        }

        public NCDDetailsViewModel GetSingleNCDDetail(int ncd_detail_id)
        {
            NCDDetail = new NCDDetailsViewModel();
            //var customerAddress = new CustomerAddressVM();
            //CustomerAddresses = new List<CustomerAddressVM>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_NCDDetails + "/" + ncd_detail_id.ToString());

                if (response.IsSuccessStatusCode)
                {

                    var dataObjects = response.Content.ReadFromJsonAsync<NCDDetailsViewModel>().Result;
                    NCDDetail = dataObjects;
                    //var addressListlist = customerAddress.GetCustomerAddressList().Where(x => x.CustomerId == NCDDetail.CustomerId).ToList();
                    //foreach (var address in addressListlist)
                    //{
                    //CustomerAddresses.Add(address);

                    //}
                }
                //NCDDetail.CustomerAddresses = CustomerAddresses;
                response.EnsureSuccessStatusCode();
                return NCDDetail;
            }
            catch (Exception)
            {
                return NCDDetail;
                throw;
            }
        }
        public async Task<int> AddSingleNCDDetail(NCDDetailsViewModel ncd_detail)
        {
            try
            {

                if (ncd_detail != null)
                {
                    HttpResponseMessage response = await PostResponse(Api_Address, ApiController_NCDDetails, ncd_detail);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        NCDDetailsViewModel responseModel = JsonConvert.DeserializeObject<NCDDetailsViewModel>(responseBody);
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
        public async Task<int> EditSingleNCDDetail(NCDDetailsViewModel ncd_details)
        {
            try
            {
                if (ncd_details != null)
                {
                    HttpResponseMessage response = await PutResponse(Api_Address, ApiController_NCDDetails, ncd_details.ID.ToString(), ncd_details);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        NCDDetailsViewModel responseModel = JsonConvert.DeserializeObject<NCDDetailsViewModel>(responseBody);
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
        public void DeleteSingleNCDDetail(int id)
        {
            try
            {
                HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_NCDDetails, id.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
