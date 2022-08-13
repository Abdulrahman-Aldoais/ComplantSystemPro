using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.UsersService.Reposetory
{
    public interface IUserRepository<T> where T : class, new()
    {
        //IQueryable<T> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        IQueryable<T> GetAllUserBlockedAsync();
        IQueryable<T> Search(string term);
        Task<T> TogelBlockUserAsync(string UserId);
        Task<int> UserRegistrationCountAsync();
        Task ChaingeStatusAsync(string id, bool isBlocked);
        Task<int> UserRegistrationCountAsync(int month);
    }
}
