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
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;

        //public AccountController(SignInManager<IdentityUser>signInManager,UserManager<IdentityUser>userManager )
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}


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
        public async Task<IActionResult> Login(LoginViewModel model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
              var result = await _signInManager.PasswordSignInAsync(model.IdentityNumber, model.Password,true,true);
                if (!await _roleManager.RoleExistsAsync(
              UserRoles.AdminVillages))
                {
                    await _roleManager.CreateAsync(new ApplicationRole(UserRoles.AdminVillages));
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ManageCategoryes",  new { Area = "AdminGeneralFederation" });
                    //return RedirectToPage("/ManageCategoryes/Index",  new { area = "AdminGeneralFederation" });
                }
            }
            return View(model);
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

