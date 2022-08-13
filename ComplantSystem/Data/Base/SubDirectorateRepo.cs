using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.Beneficiaries.Data.Base
{

    public class SubDirectorateRepo : ILocationRepo<SubDirectorate>
    {

        private readonly AppCompalintsContextDB _context;
        public SubDirectorateRepo(AppCompalintsContextDB context)
        {
            _context = context;
        }

        public List<SubDirectorate> ListByFilter(Func<SubDirectorate, bool> lamda)
        {
            var s = _context.SubDirectorates.Where(lamda).ToList();
            return s;
        }
        public  List<SubDirectorate> List()
        {
            var s = _context.SubDirectorates.ToList();
            return s;
        }

        public SubDirectorate Find(int Id)
        {
            var s = _context.SubDirectorates.Find(Id);
            return s;
        }

    }
}
