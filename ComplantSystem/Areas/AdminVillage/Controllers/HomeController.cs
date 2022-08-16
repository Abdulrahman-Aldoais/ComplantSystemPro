using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Areas.AdminVillage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
