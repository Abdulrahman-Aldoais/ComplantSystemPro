using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Models.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.VillagesUsers.Service
{
    public interface IVillageService : IEntityBaseRepository<Compalint>
    {




        //Task<IEnumerable<Compalint>> GetAllCompalintsAsync();
        Task<IEnumerable<Compalint>> GetAllCompalintsByLocalAsync(params Expression<Func<Compalint, object>>[] includeproperties);

        Task DeleteAsync(int id, int userId);

        Task IncreamentComplaintSolutionsCount(int id);

        Task<int> GetComplaintSolutionsCount();

    }
}
