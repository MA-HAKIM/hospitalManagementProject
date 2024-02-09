using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagement_UI.ViewModels
{
    public class NCDDetailsViewModel:BaseModel
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int NCDID { get; set; }
        public NCDDetailsViewModel NCDDetail { get; set; }
        public IList<NCDDetailsViewModel> NCDDetailList { get; set; }


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
        public void AddSingleNCDDetail(string ncd_detail)
        {
            NCDDetailsViewModel obj = new NCDDetailsViewModel();
            //CustomerAddressVM customerAddress = new CustomerAddressVM();
            Random randId = new Random();
            //List<NCDDetailsViewModel> data = new JavaScriptSerializer().Deserialize<List<NCDDetailsViewModel>>(ncd_detail);

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
                Task<HttpResponseMessage> response1 = PostResponse(Api_Address, ApiController_NCDDetails, obj);

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
        public void EditSingleNCDDetail(string ncd_detail)
        {
            NCDDetailsViewModel obj = new NCDDetailsViewModel();
            //CustomerAddressVM customerAddress = new CustomerAddressVM();
            Random randId = new Random();
            //List<NCDDetailsViewModel> data = new JavaScriptSerializer().Deserialize<List<NCDDetailsViewModel>>(ncd_detail);

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

                //    Task<HttpResponseMessage> response1 = PutResponse(Api_Address, ApiController_NCDDetails, cust.Id.ToString(), obj);

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
        public void DeleteSingleNCDDetail(int id)
        {
            //var address = new CustomerAddressVM();
            try
            {
                //var custId = GetCustomerList().Where(x => x.CustomerId == id).FirstOrDefault();
                //HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_NCDDetails, custId.Id.ToString());

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
