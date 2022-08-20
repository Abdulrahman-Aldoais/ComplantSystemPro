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
        public SignInManager<ApplicationUser> _SignInManager { get; }
        public UserManager<ApplicationUser> _UserManager { get; }
        public RoleManager<ApplicationRole> _RoleManager { get; }

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
            _RoleManager = roleManager;
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

            if (!ModelState.IsValid)
            {
                var UserName = loginVM.IdentityNumber;
                var user = await _UserManager.FindByEmailAsync(loginVM.IdentityNumber);
                if (user != null)
                {
                    UserName = user.UserName;
                    var passwordCheck = await _UserManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        if (await _UserManager.IsEmailConfirmedAsync(user))
                        {
                            var result = await _SignInManager.PasswordSignInAsync(loginVM.IdentityNumber, loginVM.Password, loginVM.RememberMe, false);
                            if (result.Succeeded)
                            {
                                if (!string.IsNullOrEmpty(returnUrl))
                                {

                                    return LocalRedirect(returnUrl);
                                }
                                else if (User.IsInRole(UserRoles.AdminGeneralFederation))
                                {
                                    return RedirectToAction("ContentManagementsGeneralFederation", "AdminGeneralFederation");

                                }
                                else if (User.IsInRole(UserRoles.Beneficiarie))
                                {
                                    return RedirectToAction("Complaints", "Beneficiarie");

                                }
                                else if (User.IsInRole(UserRoles.AdminGovernorate))
                                {
                                    return RedirectToAction("ContentManagementsGeneralFederation", "AdminGeneralFederation");

                                }

                                //return RedirectToAction("Create", "Uploads");
                            }
                            else
                            {
                                TempData["Error"] = "الرجاء تنشيط الحساب من قبل المسؤول ";
                                return View(loginVM);
                            }
                        }

                        TempData["Error"] = "خطا في كلمة السر او الايميل ";

                        return View(loginVM);


                    }
                    TempData["Error"] = "خطا في كلمة السر او الايميل ";


                    return View(loginVM);

                }
            }
            return View();
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
                var result = await _UserManager.CreateAsync(user, models.Password);
                if (result.Succeeded)
                {
                    await _SignInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "ManageCategoryes", new { Area = "AdminGeneralFederation" });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> LogOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
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
                var result = await _UserManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await _SignInManager.SignInAsync(user, isPersistent: false);
                    await _UserManager.AddToRoleAsync(user, UserRoles.AdminGeneralFederation);
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

