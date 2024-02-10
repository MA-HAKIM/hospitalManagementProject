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
            return View();
        }

        public IActionResult PatientList()
        {
            var patientModel = new PatientViewModel();
            var patientList = patientModel.GetPatientsList().OrderByDescending(x=>x.PatientInformationID).ToList();
            return View(patientList);
        }

        public IActionResult PatientInfoView(int id)
        {
            var patientModel = new PatientViewModel();
            var detailsView = patientModel.GetSinglePatient(id);
            return View(detailsView);
        }
        public async Task<IActionResult> SaveAndUpdate(PatientSaveViewModel patientSaveViewModel)
        {
            var patientModel = new PatientViewModel();
            var allergyDetailsModel = new AllergiesDetailsViewModel();
            var ncdDetailsModel = new NCDDetailsViewModel();

            if (patientSaveViewModel!=null)
            {
                var patientInfo = new PatientViewModel();
                patientInfo.PatientInformationID = patientSaveViewModel.PatientInformationID;
                patientInfo.PatientName = patientSaveViewModel.PatientName;
                patientInfo.DiseaseId = patientSaveViewModel.DiseaseID;
                patientInfo.Epilepsy = patientSaveViewModel.Epilepsy;
                patientInfo.Age = 0;

                if(patientSaveViewModel.PatientInformationID > 0)
                {
                    var patientId = await patientInfo.EditSinglePatient(patientInfo);

                    if (patientSaveViewModel.AllergiesList != null)
                    {
                        var allergyDetails = new AllergiesDetailsViewModel();
                        var allergieDetailsList = allergyDetails.GetAllergiesDetailListByPatientId(patientId);
                        if (allergieDetailsList != null)
                        {
                            foreach (var alg in allergieDetailsList)
                            {
                                allergyDetails.DeleteSingleAllergiesDetail(alg.ID);
                            }
                        }

                        foreach (var a in patientSaveViewModel.AllergiesList)
                        {
                            allergyDetails.PatientInformationID = patientId;
                            allergyDetails.AllergiesID = a;
                            await allergyDetailsModel.AddSingleAllergiesDetail(allergyDetails);
                        }
                    }
                    if (patientSaveViewModel.NCDList != null)
                    {
                        var ncdDetails = new NCDDetailsViewModel();
                        var oldNcdDetailsList = ncdDetails.GetNCDDetailListByPatientId(patientId);
                        if (oldNcdDetailsList != null)
                        {
                            foreach (var nd in oldNcdDetailsList)
                            {
                                ncdDetails.DeleteSingleNCDDetail(nd.ID);
                            }
                        }

                        foreach (var n in patientSaveViewModel.NCDList)
                        {
                            
                            ncdDetails.PatientInformationID = patientId;
                            ncdDetails.NCDID = n;
                            await ncdDetailsModel.AddSingleNCDDetail(ncdDetails);
                        }
                    }
                }
                else
                {
                    var patientId = await patientInfo.AddSinglePatient(patientInfo);

                    if (patientSaveViewModel.AllergiesList != null)
                    {
                        foreach (var a in patientSaveViewModel.AllergiesList)
                        {
                            var allergyDetails = new AllergiesDetailsViewModel();
                            allergyDetails.PatientInformationID = patientId;
                            allergyDetails.AllergiesID = a;

                            await allergyDetailsModel.AddSingleAllergiesDetail(allergyDetails);
                        }
                    }
                    if (patientSaveViewModel.NCDList != null)
                    {
                        foreach (var n in patientSaveViewModel.NCDList)
                        {
                            var ncdDetails = new NCDDetailsViewModel();
                            ncdDetails.PatientInformationID = patientId;
                            ncdDetails.NCDID = n;

                            await ncdDetailsModel.AddSingleNCDDetail(ncdDetails);
                        }
                    }
                }
                
            }
            return RedirectToAction("PatientList", "Patient");
        }
        public IActionResult PatientEditForView(int id)
        {
            var Disease = new DiseaseViewModel();
            ViewBag.DiseaseList = Disease.GetDiseaseDataList();

            var Allergi = new AllergiesViewModel();
            ViewBag.AllergiesList = Allergi.GetAllergiesDataList();

            var NCD = new NCDViewModel();
            ViewBag.NCDList = NCD.GetNCDDataList();

            ViewBag.PatientId = id;
            return View();
        }
        public IActionResult PatientEdit(int id)
        {
            var patientModel = new PatientViewModel();
            var detailsView = patientModel.GetSinglePatient(id);
            return Json(detailsView);
        }
        public IActionResult Delete(int patientId)
        {
            var patientModel = new PatientViewModel();
            var patinetDetails = patientModel.GetSinglePatient(patientId);
            return View(patinetDetails);
        }

        public IActionResult DeletePatient(int patientId)
        {
            var patientModel = new PatientViewModel();
            patientModel.DeleteSinglePatient(patientId);

            return RedirectToAction("PatientList", "Patient");
        }
    }
}
