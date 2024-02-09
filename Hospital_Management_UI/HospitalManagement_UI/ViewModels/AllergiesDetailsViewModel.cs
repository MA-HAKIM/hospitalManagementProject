using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagement_UI.ViewModels
{
    public class AllergiesDetailsViewModel:BaseModel
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int AllergiesID { get; set; }
        public AllergiesDetailsViewModel AllergiesDetail { get; set; }
        public IList<AllergiesDetailsViewModel> AllergiesDetailList { get; set; }


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
        public void AddSingleAllergiesDetail(string Allergies_detail)
        {
            AllergiesDetailsViewModel obj = new AllergiesDetailsViewModel();
            //CustomerAddressVM customerAddress = new CustomerAddressVM();
            Random randId = new Random();
            //List<AllergiesDetailsViewModel> data = new JavaScriptSerializer().Deserialize<List<AllergiesDetailsViewModel>>(Allergies_detail);

            try
            {
                //foreach (var cust in data)
                //{
                //obj.CustomerName = cust.CustomerName;
                //obj.CountryId = cust.CountryId;
                //obj.CustomerId = randId.Next(1000, 99999);
                //obj.FatherName = cust.FatherName;
                //obj.MotherName = cust.MotherName;
                //obj.MaritalStatus = cust.MaritalStatus;
                //obj.CustomerPhoto = cust.CustomerPhoto;
                Task<HttpResponseMessage> response1 = PostResponse(Api_Address, ApiController_AllergiesDetails, obj);

                //foreach (var address in cust.Addresses)
                //{
                //customerAddress.CustomerAddress = address;
                //customerAddress.CustomerId = obj.CustomerId;
                //Task<HttpResponseMessage> response = PostResponse(Api_Address, ApiController_CustomerAddress, customerAddress);
                //}
                //}

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EditSingleAllergiesDetail(string Allergies_detail)
        {
            AllergiesDetailsViewModel obj = new AllergiesDetailsViewModel();
            //CustomerAddressVM customerAddress = new CustomerAddressVM();
            Random randId = new Random();
            //List<AllergiesDetailsViewModel> data = new JavaScriptSerializer().Deserialize<List<AllergiesDetailsViewModel>>(Allergies_detail);

            try
            {
                //foreach (var cust in data)
                //{
                //    obj.Id = cust.Id;
                //    obj.CustomerName = cust.CustomerName;
                //    obj.CountryId = cust.CountryId;
                //    obj.CustomerId = cust.CustomerId;
                //    obj.FatherName = cust.FatherName;
                //    obj.MotherName = cust.MotherName;
                //    obj.MaritalStatus = cust.MaritalStatus;
                //    obj.CustomerPhoto = cust.CustomerPhoto;

                //    Task<HttpResponseMessage> response1 = PutResponse(Api_Address, ApiController_AllergiesDetails, cust.Id.ToString(), obj);

                //    var customerAddressList = customerAddress.GetCustomerAddressList()
                //        .Where(x => x.CustomerId == cust.CustomerId).ToList();

                //    foreach (var d in customerAddressList)
                //    {
                //        customerAddress.DeleteSingleCustomerAddress(d.Id);
                //    }

                //    foreach (var address in cust.Addresses)
                //    {

                //        customerAddress.CustomerAddress = address;
                //        customerAddress.CustomerId = obj.CustomerId;
                //        Task<HttpResponseMessage> response = PutResponse(Api_Address, ApiController_CustomerAddress, cust.Id.ToString(), customerAddress);
                //        Thread.Sleep(5);
                //    }

                //}

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteSingleAllergiesDetail(int id)
        {
            //var address = new CustomerAddressVM();
            try
            {
                //var custId = GetCustomerList().Where(x => x.CustomerId == id).FirstOrDefault();
                //HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_AllergiesDetails, custId.Id.ToString());

                //foreach (var custAddress in address.GetCustomerAddressList().Where(x => x.CustomerId == id).ToList())
                //{
                //    HttpResponseMessage response2 = DeleteResponse(Api_Address, ApiController_CustomerAddress, custAddress.Id.ToString());
                //}

                //if (response.IsSuccessStatusCode)
                //{

                //}
                //response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
