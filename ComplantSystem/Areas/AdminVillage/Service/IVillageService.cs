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
    public interface IVillageService : IEntityBaseRepository<UploadsComplainte>
    {




        //Task<IEnumerable<Compalint>> GetAllCompalintsAsync();
        Task<IEnumerable<UploadsComplainte>> GetAllCompalintsByLocalAsync(params Expression<Func<UploadsComplainte, object>>[] includeproperties);

        Task DeleteAsync(int id, int userId);

        Task IncreamentComplaintSolutionsCount(int id);

        Task<int> GetComplaintSolutionsCount();

    }
}
