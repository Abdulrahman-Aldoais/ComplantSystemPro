using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminGeneralFederation.Service
{
    public interface ICategoryService 
    {
        Task<TypeComplaint> GetByIdAsync(string id);
        Task UpdateAsync(string id, TypeComplaint entity);
        Task DeleteAsync(string id);
        Task AddCategoruComp(TypeComplaint entity);
        Task AddCategoruComm(TypeComplaint entity);
        Task<IEnumerable<TypeComplaint>> GetAllGategoryCompAsync();
        Task<IEnumerable<TypeComplaint>> GetAllGategoryCommAsync();


    }
}
