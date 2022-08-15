using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;

using System.Threading.Tasks;
using System.Collections.Generic;
using ComplantSystem.Areas.Beneficiarie.ViewModels;
using System.Linq;

namespace ComplantSystem
{
    public interface ICompalintService : IEntityBaseRepository<UploadsComplainte>
    {

        IQueryable<UploadsComplainte> GetAll();
        Task<UploadsComplainte> FindAsync(string id);
        Task<UploadsComplainte> GetCompalintById(string id);
        IQueryable<UploadsComplainte> GetBy(string userId);

        Task<IEnumerable<UploadsComplainte>> GetAllRejectedComplaints();
        Task CreateAsync(InputCompmallintVM model);
        Task CreateAsync2(InputCompmallintVM model);
        //Task AddNewCompalintAsync(UploadsComplainte data);

        //Task CreateAsync(InputUpload model);
        //IQueryable<Compalint> GetAll();

        //Task<NewCompalintVM> FindAsync(string id);



        Task DeleteAsync(string id, string userId);

        Task IncreamentDownloadCount(string id);

        Task<int> GetUploadsCount();
        Task GetAllGategoryCompAsync();
        Task UpdateAsync(string id, TypeComplaint typeComplaint);
    }
}
