using ComplantSystem.Areas.AdminService.Service;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminGeneralFederation.Controllers
{
    [Area("AdminGeneralFederation")]
    public class SetingProfileController : Controller
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        //private readonly ICategoryService _service;

        public SetingProfileController(AppCompalintsContextDB context,IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.userService = userService;
            this.userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
       public async Task<IActionResult> Profile()
        {

            var account = await _signInManager.UserManager.GetUserAsync(User);
            if (account == null)
                return NotFound();
            else
                return View(account);

        }
        public async Task<IActionResult> EditeProfile()
        {
            return View();
        }
        public async Task<IActionResult> Chenginpassword()
        {
            return View();
        }
    }
}
