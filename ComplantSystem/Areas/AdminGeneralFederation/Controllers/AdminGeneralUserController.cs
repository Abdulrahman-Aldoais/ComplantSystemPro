using ComplantSystem.Areas.AdminService.Service;
using ComplantSystem.Areas.UsersService.ViewModel;
using ComplantSystem.Areas.VillagesUsers.Models;
using ComplantSystem.Const;

using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly RoleManager<ApplicationRole> roleManager;

        public AdminGeneralUserController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index(
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var result = await userService.GetAllAsync(h => h.Governorates);


            if (!String.IsNullOrEmpty(searchString))
            {

            }

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;

            int pageSize = 3;



            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

        }
        public async Task<IActionResult> BeneficiariesAccount()
        {
            return View();

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


        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var users = await userService.GetAllAsync();
            ViewBag.UserCount = users.Count();

            var user = await userService.GetByIdAsync((string)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            var users = await userService.GetAllAsync();
            ViewBag.UserCount = users.Count();
            var user = await userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var newUser = new EditUserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IsBlocked = user.IsBlocked,
                //userRoles = user.UserRoles,


            };
            return View(newUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel user)
        {
            var users = await userService.GetAllAsync();
            ViewBag.UserCount = users.Count();
            if (ModelState.IsValid)
            {
                try
                {
                    await userService.UpdateAsync(id, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> ChaingeStatusAsync(string id, bool IsBlocked)
        {
            await userService.ChaingeStatusAsync(id, IsBlocked);
            return RedirectToAction("Index");
        }

        private bool UserExists(string id)
        {
            return string.IsNullOrEmpty(userService.GetByIdAsync(id).ToString());
        }


    }



}
