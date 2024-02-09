using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_UI.ViewModels
{
    public enum Epilepsy
    {
        No = 0,
        Yes = 1
    }
    public class PatientViewModel:BaseModel
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public Epilepsy EpilepsyList { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public int DiseaseId { get; set; }
        public PatientViewModel Patient { get; set; }
        public IList<PatientViewModel> PatientList { get; set; }


        public IList<PatientViewModel> GetPatientsList()
        {
            PatientList = new List<PatientViewModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_PatientsInfo);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<PatientViewModel>>().Result;
                    PatientList = (IList<PatientViewModel>)dataObjects.ToList();
                }

                response.EnsureSuccessStatusCode();
                return PatientList;
            }
            catch (Exception)
            {
                return PatientList;
                throw;
            }
        }
        public PatientViewModel GetSinglePatient(int patient_id)
        {
            Patient = new PatientViewModel();
            //var customerAddress = new CustomerAddressVM();
            //CustomerAddresses = new List<CustomerAddressVM>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_PatientsInfo + "/" + patient_id.ToString());

                if (response.IsSuccessStatusCode)
                {

                    var dataObjects = response.Content.ReadFromJsonAsync<PatientViewModel>().Result;
                    Patient = dataObjects;
                    //var addressListlist = customerAddress.GetCustomerAddressList().Where(x => x.CustomerId == Patient.CustomerId).ToList();
                    //foreach (var address in addressListlist)
                    //{
                        //CustomerAddresses.Add(address);

                    //}
                }
                //Patient.CustomerAddresses = CustomerAddresses;
                response.EnsureSuccessStatusCode();
                return Patient;
            }
            catch (Exception)
            {
                return Patient;
                throw;
            }
        }
        public void AddSinglePatient(string patient)
        {
            PatientViewModel obj = new PatientViewModel();
            //CustomerAddressVM customerAddress = new CustomerAddressVM();
            Random randId = new Random();
            //List<PatientViewModel> data = new JavaScriptSerializer().Deserialize<List<PatientViewModel>>(patient);

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
                    Task<HttpResponseMessage> response1 = PostResponse(Api_Address, ApiController_PatientsInfo, obj);

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
        public void EditSinglePatient(string patient)
        {
            PatientViewModel obj = new PatientViewModel();
            //CustomerAddressVM customerAddress = new CustomerAddressVM();
            Random randId = new Random();
            //List<PatientViewModel> data = new JavaScriptSerializer().Deserialize<List<PatientViewModel>>(patient);

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

                //    Task<HttpResponseMessage> response1 = PutResponse(Api_Address, ApiController_PatientsInfo, cust.Id.ToString(), obj);

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
        public void DeleteSinglePatient(int id)
        {
            //var address = new CustomerAddressVM();
            try
            {
                //var custId = GetCustomerList().Where(x => x.CustomerId == id).FirstOrDefault();
                //HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_PatientsInfo, custId.Id.ToString());

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
