using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;


namespace ComplantSystem
{
    public class CompalintService : EntityBaseRepository<UploadsComplainte>
    {
        public CompalintService(AppCompalintsContextDB context) : base(context) { }
    }
}
