using ComplantSystem.Areas.UsersService.ViewModel;
using ComplantSystem.Data;
using ComplantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminService.Service
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task UpdateAsync(string id, EditUserViewModel entity);

        //Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeproperties);
        IQueryable<ApplicationUser> GetAllUserBlockedAsync();
        //Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        //Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties);
        IQueryable<AdminUserViewModel> Search(string term);
        Task<OperationResult> TogelBlockUserAsync(string UserId);
        Task<int> UserRegistrationCountAsync();
        Task ChaingeStatusAsync(string id, bool status);
        Task<int> UserRegistrationCountAsync(int month);
        //Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues();
        Task InitializeAsync();
    }
}
