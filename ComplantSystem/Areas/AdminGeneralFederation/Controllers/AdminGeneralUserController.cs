using ComplantSystem.Areas.AdminService.Service;
using ComplantSystem.Areas.UsersService.ViewModel;
using ComplantSystem.Areas.VillagesUsers.Models;
using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminGeneralFederation.Controllers
{
    [Area("AdminGeneralFederation")]
    public class AdminGeneralUserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminGeneralUserController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllAsync(p => p.Role, h => h.Governorates);

            return View(result.ToList());
        }

        public IActionResult Block()
        {
            var result = userService.GetAllUserBlockedAsync();
            return View(result);
        }

        [HttpPost]
        public IActionResult Search(InputSearch input)
        {
            if (ModelState.IsValid)
            {
                var result = userService.Search(input.Term);
                return View(result);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Block(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var result = await userService.TogelBlockUserAsync(userId);
                if (result.Success)
                {
                    TempData["Succes"] = result.Message;
                }
                else
                {
                    TempData["Error"] = result.Message;
                }
                return RedirectToAction("Index");
            }
            TempData["Error"] = "لم يتم العثور على رقم المستخدم";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> AccountRestriction()
        {
            var result = await userService.GetAllAsync(p => p.Role, h => h.Governorates);

            return View(result.ToList());
          
        }



        public async Task<IActionResult> UsersCounts()
        {
            var totalUsersCount = await userService.UserRegistrationCountAsync();
            var month = DateTime.Today.Month;
            var monthUsersCount = await userService.UserRegistrationCountAsync(month);

            return Json(new { tota = totalUsersCount, month = monthUsersCount });

        }

        [HttpGet]
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
                    Email = userVM.IdentityNumber,
                    PhoneNumber = userVM.PhoneNumber,
                    GovernorateId = userVM.GovernorateId,
                    IsBlocked = userVM.IsBlocked,
                    SocietyId = userVM.SocietyId,
                    ProfilePicture = userVM.ProfilePicture,
                    Password = userVM.Password,

                };
                var result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    await userManager.AddToRoleAsync(user, UserRoles.AdminGeneralFederation);
                    return RedirectToAction("Index", "AllUsers");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("تعذر انشاء الحساب ", error.Description);
                }

            }
            return View(userVM);

        }

        public async Task<IActionResult> ChaingeStatusAsync(string id , bool IsBlocked)
        {
           await  userService.ChaingeStatusAsync(id, IsBlocked);
            return RedirectToAction("Index");

        }


    }



}
