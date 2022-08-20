using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Areas.AdminGovernorate.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
