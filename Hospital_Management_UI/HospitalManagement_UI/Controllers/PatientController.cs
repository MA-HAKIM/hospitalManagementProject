using HospitalManagement_UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement_UI.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult PatientInfo()
        {
            var Disease = new DiseaseViewModel();
            ViewBag.DiseaseList = Disease.GetDiseaseDataList();

            var Allergi = new AllergiesViewModel();
            ViewBag.AllergiesList = Allergi.GetAllergiesDataList();

            var NCD = new NCDViewModel();
            ViewBag.NCDList = NCD.GetNCDDataList();

            var patient = new PatientViewModel();

            //List<Epilepsy> enumList = Enum.GetValues(typeof(Epilepsy)).Cast<Epilepsy>().ToList();
            //var EList = enumList.OrderByDescending(x => x);
            //ViewBag.EList = EList;
            return View(patient);
        }

        public IActionResult PatientList()
        {
            return View();
        }
        public IActionResult SaveAndUpdate()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
