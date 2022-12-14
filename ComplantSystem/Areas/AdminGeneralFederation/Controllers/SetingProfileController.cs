using AutoMapper;
using ComplantSystem.Areas.AdminService.Service;
using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminGeneralFederation.Controllers
{
    [Area("AdminGeneralFederation")]
    [Authorize(Roles = UserRoles.AdminGeneralFederation)]

    public class SetingProfileController : Controller
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper mapper;


        //private readonly ICategoryService _service;

        public SetingProfileController(
            AppCompalintsContextDB context,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper

            )
        {
            _context = context;
            this.userService = userService;
            this.userManager = userManager;
            _signInManager = signInManager;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var currentUser = await userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var model = mapper.Map<UsersViewModel>(currentUser);
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.IdentityNumber = model.IdentityNumber;
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;

                    var result = await userManager.UpdateAsync(currentUser);
                    if (result.Succeeded)
                    {
                        //TempData["Success"] = stringLocalizer["SuccessMessage"]?.Value;
                        return RedirectToAction("Profile");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return View("Empty");
                }
            }
            return View(model);
        }




        public async Task<IActionResult> Edit()
        {



            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var model = new EditUserViewModel
                {
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    DateOfBirth = currentUser.DateOfBirth,
                    PhoneNumber = currentUser.PhoneNumber,
                    CreatedDate = System.DateTime.Now,

                };
                return View(model);
            }
            return View("Empty");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;

                    var result = await userManager.UpdateAsync(currentUser);
                    if (result.Succeeded)
                    {
                        //TempData["Success"] = stringLocalizer["SuccessMessage"]?.Value;
                        return RedirectToAction("Profile");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return View("Empty");
                }
            }
            return View(model);
        }


        //private bool UserExists(string id)
        //{
        //    return string.IsNullOrEmpty(userService.GetByIdAsync(id).ToString());
        //}


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {


            //var user = await _signInManager.UserManager.GetUserAsync(User);
            //if (!ModelState.IsValid)
            //{
            //    if (user == null)
            //        return NotFound();
            //    else
            //    {
            //        if (changePassword == null)
            //            return BadRequest();

            //        var result = await userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            //        if (result.Succeeded)
            //        {
            //            TempData["SuccessChanges"] = "تم تغيير كلمة السر بنجاح";
            //            return RedirectToAction("ChangePassword");

            //        }

            //        else
            //            TempData["Error"] = "كلمة المرور السابقة خاطئة";

            //    }

            //}
            //return View(changePassword);



            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await userManager.ChangePasswordAsync(currentUser, changePassword.CurrentPassword, changePassword.NewPassword);
                    if (result.Succeeded)
                    {
                        //TempData["Success"] = stringLocalizer["ChangePasswordMessage"]?.Value;
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Login");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                return NotFound();
            }
            return View("ChangePassword", mapper.Map<UsersViewModel>(currentUser));


        }
        public async Task<IActionResult> ChangePassword()
        {
            return View();

        }

    }
}
