using ComplantSystem.Models.Data.ViewModels;
using ComplantSystem.Models.Benef;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace ComplantSystem.Models.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase,  new()
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        Task<T> GetByIdAsync(string id);
        Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues();
        Task AddNewSolutionCompalintAsync(string id, T entity);
        Task AddUser(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
        //Task<int> GetAllCount();

        Task<IEnumerable<T>> GetAllBenficiareByLocalAsync(params Expression<Func<T, object>>[] includeproperties);

        //Task UpdateCompalintAsync(string id, T entity);
        //Task DeleteCompalintAsync(string id);
        //Task SelectCascadingDropdwon(T entiry);
   

    }
}
