using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Areas.Beneficiarie.Controllers
{
    public class CommunicationsController : Controller
    {
        [Area("Beneficiarie")]
        public IActionResult AllCommunication()
        {
            return View();
        }
        public IActionResult AddCommunication()
        {
            return View();
        }
    }
}
