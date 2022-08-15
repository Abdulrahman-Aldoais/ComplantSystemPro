using ComplantSystem.Areas.UsersService.ViewModel;
using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComplantSystem.Controllers
{
    public class AccountController : Controller
    {



        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM, string returnUrl)
        {
            TempData["Error"] = null;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.IdentityNumber, loginVM.Password, true, true);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {

                        return LocalRedirect(returnUrl);
                    }
                    else if ( User.IsInRole(UserRoles.AdminGeneralFederation))
                    {
                        return RedirectToAction("ContentManagementsGeneralFederation", "AdminGeneralFederation");

                    }
                    else if (User.IsInRole(UserRoles.AdminVillages))
                    {
                        return RedirectToAction("Complaints", "Beneficiarie");

                    }
                    else if(User.IsInRole(UserRoles.AdminGovernorate))
                    {
                        return RedirectToAction("ContentManagementsGeneralFederation", "AdminGeneralFederation");

                    }

                    //return RedirectToAction("Create", "Uploads");
                }
            }
            return View(loginVM);

        }

        [HttpGet]
        public IActionResult Regster()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Regster(RegisterViewModel models)
        {
            //ViewBag.Rols = new SelectList(moviesDropdwonsData, "Id", "Name");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = models.IdentityNumber,
                    Email = models.IdentityNumber,
                    PhoneNumber = models.PhoneNumber,
                    GovernorateId = models.GovernorateId,
                    CreatedDate = models.CreatedDate,
                    SocietyId = models.SocietyId,
                    ProfilePicture = models.ProfilePicture,
                    
               
                };
                  var result = await _userManager.CreateAsync(user, models.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "ManageCategoryes", new { Area = "AdminGeneralFederation" });
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult AddUser()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AdminUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    UserName = userVM.IdentityNumber,
                    IdentityNumber = userVM.IdentityNumber,
                    Email = userVM.IdentityNumber,
                    PhoneNumber = userVM.PhoneNumber,
                    GovernorateId = userVM.GovernorateId,
                    CreatedDate = userVM.CreatedDate,
                    SocietyId = userVM.SocietyId,
                    ProfilePicture = userVM.ProfilePicture,
                    Password = userVM.Password,

                };
                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, UserRoles.AdminGeneralFederation);
                    return RedirectToAction("Index", "AllUsers");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(userVM);

        }

    }

}

