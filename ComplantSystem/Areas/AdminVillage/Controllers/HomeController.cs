using ComplantSystem.Areas.AdminVillage.Service;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminVillage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompalintRepository reposComp;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IManagementUsers usersReop;

        public HomeController(
            ICompalintRepository reposComp,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IManagementUsers usersReop
            )
        {
            this.reposComp = reposComp;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.usersReop = usersReop;
        }

        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }



        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var userDirectoratesId = currentUser.Directorates.Id;

            var complaints = reposComp.GetBy(UserId).Where(u => u.StatusCompalintId == 1 && u.Directorates.Id == userDirectoratesId);

            return View(complaints.ToList());
        }

        public async Task<IActionResult> ViewBenf()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var userVillageId = currentUser.Village.Id;

            var Benf = usersReop.GetAllUsersAsync().Where(b => b.Village.Id == userVillageId);

            return View();
        }
    }
}
