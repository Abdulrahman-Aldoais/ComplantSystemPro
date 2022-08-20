using Microsoft.AspNetCore.Mvc;

namespace ComplantSystem.Areas.AdminVillage.Controllers
{
    public class ManagementUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
