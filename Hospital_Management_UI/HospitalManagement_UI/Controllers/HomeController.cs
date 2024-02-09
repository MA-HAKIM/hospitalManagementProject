using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement_UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
