using AutoMapper;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.UsersService.Reposetory
{
    public class UserRepository<T> : IUserRepository<T> where T : class, new()
    {

        private readonly AppCompalintsContextDB contex;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(
            AppCompalintsContextDB contex,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppCompalintsContextDB _context
            )
        {
            this.contex = contex;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
           
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

        public async Task<IEnumerable<T>> GetAllAsync()=> await contex.Set<T>().ToListAsync();
        //{
        //    var result = contex.Users.OrderByDescending(u => u.CreatedDate);
        //    //.ProjectTo<ApplicationUser>(mapper.ConfigurationProvider)
        //    return result;
        //}

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties)
        {
            System.Linq.IQueryable<T> query = contex.Set<T>();
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();
        }

        public System.Linq.IQueryable<T> GetAllUserBlockedAsync()
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<T> Search(string term)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> TogelBlockUserAsync(string UserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UserRegistrationCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UserRegistrationCountAsync(int month)
        {
            throw new System.NotImplementedException();
        }
    }
}
