using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;

namespace ComplantSystem.Areas.VillagesUsers.Service
{
    public class VillageService : EntityBaseRepository<UploadsComplainte>
    {

        public VillageService(AppCompalintsContextDB context) : base(context) { }



    }
}
