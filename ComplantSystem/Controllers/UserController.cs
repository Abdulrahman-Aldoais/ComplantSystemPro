//using ComplantSystem.Areas.UsersService.Model;
//using ComplantSystem.Areas.UsersService.Model;
//using ComplantSystem.Areas.UsersService.ViewModel;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ComplantSystem.Controllers
//{
//    public class UserController : Controller
//    {

//        private readonly UserManager<ApplicationUser> userManager;
//        private readonly RoleManager<ApplicationRole> roleManager;

//        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
//        {
//            this.userManager = userManager;
//            this.roleManager = roleManager;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            List<UserListViewModel> model = new List<UserListViewModel>();
//            model = userManager.Users.Select(u => new UserListViewModel
//            {
//                Id = u.Id,
//                Name = u.FirstName,
//                Email = u.Email
//            }).ToList();
//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult AddUser()
//        {
//            UserViewModels model = new UserViewModels();
//            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
//            {
//                Text = r.Name,
//                Value = r.Id
//            }).ToList();
//            return PartialView("_AddUser", model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddUser(UserViewModels model)
//        {
//            if (ModelState.IsValid)
//            {
//                ApplicationUser user = new ApplicationUser
//                {
//                    FirstName = model.Name,
//                    UserName = model.UserName,
//                    Email = model.Email
//                };
//                IdentityResult result = await userManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
//                    if (applicationRole != null)
//                    {
//                        IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
//                        if (roleResult.Succeeded)
//                        {
//                            return RedirectToAction("Index");
//                        }
//                    }
//                }
//            }
//            return View(model);
//        }


//        [HttpGet]
//        public async Task<IActionResult> EditUser(string id)
//        {
//            EditUserViewModel model = new EditUserViewModel();
//            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
//            {
//                Text = r.Name,
//                Value = r.Id
//            }).ToList();

//            if (!String.IsNullOrEmpty(id))
//            {
//                ApplicationUser user = await userManager.FindByIdAsync(id);
//                if (user != null)
//                {
//                    model.Name = user.FirstName;
//                    model.Email = user.Email;
//                    model.ApplicationRoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
//                }
//            }
//            return PartialView("_EditUser", model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                ApplicationUser user = await userManager.FindByIdAsync(id);
//                if (user != null)
//                {
//                    user.FirstName = model.Name;
//                    user.Email = model.Email;
//                    string existingRole = userManager.GetRolesAsync(user).Result.Single();
//                    string existingRoleId = roleManager.Roles.Single(r => r.Name == existingRole).Id;
//                    IdentityResult result = await userManager.UpdateAsync(user);
//                    if (result.Succeeded)
//                    {
//                        if (existingRoleId != model.ApplicationRoleId)
//                        {
//                            IdentityResult roleResult = await userManager.RemoveFromRoleAsync(user, existingRole);
//                            if (roleResult.Succeeded)
//                            {
//                                ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
//                                if (applicationRole != null)
//                                {
//                                    IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
//                                    if (newRoleResult.Succeeded)
//                                    {
//                                        return RedirectToAction("Index");
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            return PartialView("_EditUser", model);
//        }


//        [HttpGet]
//        public async Task<IActionResult> DeleteUser(string id)
//        {
//            string name = string.Empty;
//            if (!String.IsNullOrEmpty(id))
//            {
//                ApplicationUser ApplicationUser = await userManager.FindByIdAsync(id);
//                if (ApplicationUser != null)
//                {
//                    name = ApplicationUser.FirstName;
//                }
//            }
//            return PartialView("_DeleteUser", name);
//        }

//        [HttpPost]
//        public async Task<IActionResult> DeleteUser(string id, FormCollection form)
//        {
//            if (!String.IsNullOrEmpty(id))
//            {
//                ApplicationUser ApplicationUser = await userManager.FindByIdAsync(id);
//                if (ApplicationUser != null)
//                {
//                    IdentityResult result = await userManager.DeleteAsync(ApplicationUser);
//                    if (result.Succeeded)
//                    {
//                        return RedirectToAction("Index");
//                    }
//                }
//            }
//            return View();
//        }




//    }
//}
