using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HospitalManagement_UI.ViewModels
{
    public class PatientViewModel:BaseModel
    {
        public int PatientInformationID { get; set; }
        public string PatientName { get; set; }
        public int Epilepsy { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public int DiseaseId { get; set; }
        public PatientDetailsModel Patient { get; set; }
        public IList<PatientDetailsModel> PatientList { get; set; }
        public DiseaseViewModel DiseaseInformation { get; set; } // Navigation property
        public List<NCDDetailsViewModel> NCD_Details { get; set; } // Navigation property
        public List<AllergiesDetailsViewModel> Allergies_Details { get; set; } // Navigation property

        public IList<PatientDetailsModel> GetPatientsList()
        {
            PatientList = new List<PatientDetailsModel>();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_PatientsInfo);

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    PatientList = JsonConvert.DeserializeObject<List<PatientDetailsModel>>(data);
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
        public PatientDetailsModel GetSinglePatient(int patient_id)
        {
            Patient = new PatientDetailsModel();
            try
            {
                HttpResponseMessage response = GetResponse(Api_Address, ApiController_PatientsInfo + "/" + patient_id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var dataObjects = JsonConvert.DeserializeObject<PatientDetailsModel>(data);
                    Patient = dataObjects;
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
        public async Task<int> AddSinglePatient(PatientViewModel patient)
        {
            try
            {
                if(patient != null)
                {
                    HttpResponseMessage response = await PostResponse(Api_Address, ApiController_PatientsInfo, patient);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PatientViewModel responseModel = JsonConvert.DeserializeObject<PatientViewModel>(responseBody);
                        int id = responseModel.PatientInformationID;
                        return id;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
        public async Task<int> EditSinglePatient(PatientViewModel patient)
        {
            try
            {
                if (patient != null)
                {
                    HttpResponseMessage response = await PutResponse(Api_Address, ApiController_PatientsInfo, patient.PatientInformationID.ToString(), patient);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        PatientViewModel responseModel = JsonConvert.DeserializeObject<PatientViewModel>(responseBody);
                        int id = responseModel.PatientInformationID;
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
        public void DeleteSinglePatient(int id)
        {
            try
            {
                HttpResponseMessage response2 = DeleteResponse(Api_Address, ApiController_PatientsInfo, id.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
