using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComplantSystem.Areas.AdminService.Service;
using ComplantSystem.Areas.UsersService.ViewModel;
using ComplantSystem.Const;
using ComplantSystem.Data;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas
{
    public class UserService : IUserService
    {
        private readonly AppCompalintsContextDB contex;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly AppCompalintsContextDB context;

        public UserService(
            AppCompalintsContextDB contex,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            AppCompalintsContextDB _context
            )
        {
            this.contex = contex;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            context = _context;
        }
        public async Task<OperationResult> TogelBlockUserAsync(string UserId)
        {
            var existedUser = await contex.Users.FindAsync(UserId);
            if (existedUser == null)
            {
                return OperationResult.NotFond();
            }
            existedUser.IsBlocked = !existedUser.IsBlocked;
            contex.Update(existedUser);
            await contex.SaveChangesAsync();
            return OperationResult.Successeded();
        }



        public IQueryable<ApplicationUser> GetAllUserBlockedAsync()
        {
            var result = contex.Users.Include(c => c.Role).Where(u => u.IsBlocked).ProjectTo<ApplicationUser>(mapper.ConfigurationProvider);
            return result;
        }

        public IQueryable<AdminUserViewModel> Search(string term)
        {
            var result = contex.Users.Where(
                u => u.IdentityNumber == term
                || u.UserName == term).ProjectTo<AdminUserViewModel>(
                mapper.ConfigurationProvider);
            return result;
        }

        public async Task<int> UserRegistrationCountAsync()
        {
            var count = await contex.Users.CountAsync();
            return count;
        }

        public async Task<int> UserRegistrationCountAsync(int month)
        {
            var year = DateTime.Today.Year;
            var count = await contex.Users.CountAsync(u => u.CreatedDate.Month == month && u.CreatedDate.Year == year);
            return count;
        }



        //UserRoles.AdminGovernorate,
        //       UserRoles.AdminSubDirectorate,
        //       UserRoles.AdminDirectorate






        public async Task InitializeAsync()
        {

            //if (!await roleManager.RoleExistsAsync(
            //UserRoles.AdminGeneralFederation))
            //{
            //    await roleManager.CreateAsync(new ApplicationRole(UserRoles.AdminGeneralFederation));
            //}





            //string IdentityAdmin = "0010243124111";


            //if (await userManager.FindByEmailAsync(IdentityAdmin) == null)
            //{
            //    var user = new ApplicationUser
            //    {
            //        Email = IdentityAdmin,
            //        UserName = IdentityAdmin,
            //        PhoneNumber = "775115810",
            //        FirstName = "عبدالرحمن",
            //        LastName = "علي سرحان الدعيس",
            //        EmailConfirmed = true,
            //        PhoneNumberConfirmed = true,

            //    };
            //    await userManager.CreateAsync(user, "P@ww11");
            //    await userManager.AddToRoleAsync(user, UserRoles.AdminGeneralFederation);

            //}






            if (!await roleManager.RoleExistsAsync(
             UserRoles.Beneficiarie))
            {
                await roleManager.CreateAsync(new ApplicationRole(UserRoles.Beneficiarie));
            }

            string IdentityUser = "0010243124333";

            var appUser = await userManager.FindByEmailAsync(IdentityUser);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser()
                {
                    Email = IdentityUser,
                    UserName = IdentityUser,
                    PhoneNumber = "77453534",
                    FirstName = "صلاح محمد",
                    LastName = "عامر سعد",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                await userManager.CreateAsync(newAppUser, "B@ww11");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.Beneficiarie);
            }
        }



        public async Task ChaingeStatusAsync(string id, bool isBlocked)
        {
            var selectedItem = await contex.Users.FindAsync(id);
            if (selectedItem != null)
            {
                selectedItem.IsBlocked = isBlocked;
                contex.Update(selectedItem);
                await contex.SaveChangesAsync();
            }
        }


        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var profile = await context.Users.FindAsync(userId);
            if (profile != null)
            {
                //AutoMapper 
                var compalintDetails = context.Users
                .Include(s => s.Governorates)
                .Include(f => f.UserRoles)
                .Include(g => g.Directorates)
                .Include(d => d.SubDirectorate)
                .Include(su => su.Village)

                .FirstOrDefaultAsync(c => c.Id == userId);
                //var compalintDetails = from m in _context.UploadsComplainte select m;
                return await compalintDetails;
            }
            return null;
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {

            return await context.Set<ApplicationUser>().ToListAsync();
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<ApplicationUser> GetByIdAsync(string id) => await context.Set<ApplicationUser>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(string id, EditUserViewModel entity)
        {
            var updatedUser = await userManager.FindByIdAsync(id);
            var roleId = await userManager.GetRolesAsync(updatedUser);
            if (updatedUser == null)
                return;
            else
            {

                updatedUser.FirstName = entity.FirstName;
                updatedUser.LastName = entity.LastName;
                updatedUser.PhoneNumber = entity.PhoneNumber;

                updatedUser.IdentityNumber = entity.IdentityNumber;
                updatedUser.CreatedDate = DateTime.Now;
                updatedUser.DateOfBirth = entity.DateOfBirth;
                await userManager.UpdateAsync(updatedUser);

            }

            await context.SaveChangesAsync();
        }



    }
}
