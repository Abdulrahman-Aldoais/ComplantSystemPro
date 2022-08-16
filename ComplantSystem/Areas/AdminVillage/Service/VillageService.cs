using AutoMapper;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Models.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.VillagesUsers.Service
{
    public class VillageService : EntityBaseRepository<UploadsComplainte>, IVillageService
    {

        private readonly AppCompalintsContextDB _context;
        private readonly IMapper _mapper;
        public VillageService(AppCompalintsContextDB context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }



        public Task DeleteAsync(int id, int userId)
        {
            throw new NotImplementedException();
        }

        //public Task<IEnumerable<Compalint>> GetAllCompalintsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<IEnumerable<UploadsComplainte>> GetAllCompalintsByLocalAsync(params Expression<Func<UploadsComplainte, object>>[] includeproperties)
        {
            throw new NotImplementedException();
        }




        //public async Task<IEnumerable<Beneficiarie>> GetAllBenficiareAsync() => await _context.Set<Beneficiarie>().ToListAsync();

        //UploadsComplainte

        public System.Linq.IQueryable<UploadsComplainte> GetCompalintsByStutas(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetComplaintSolutionsCount()
        {
            throw new NotImplementedException();
        }


        //public async Task<Compalint> GetCompalintById(string id)
        //{
        //    var compalintDetails = _context.UploadsComplainte
        //       .Include(s => s.StatusCompalint)
        //       .Include(f => f.TypeComplaint)
        //       .Include(g => g.Governorates)
        //       .Include(d => d.Directorates)
        //       .Include(su => su.SubDirectorates)
        //       .Include(v => v.Villages)
        //       .Include(st => st.StagesComplaint)
        //       .Include(so => so.Beneficiaries)
        //       .Include(cs => cs.Compalints_Solutions).ThenInclude(a => a.UserAddSolution)
        //       .FirstOrDefaultAsync(c => c.Id == id);
        //    //var compalintDetails = from m in _context.UploadsComplainte select m;
        //    return await compalintDetails;
        //}


        //public async Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues()
        //{
        //    var response = new SelectDataDropdownsVM()
        //    {

        //        StatusCompalints = await _context.StatusCompalints.OrderBy(n => n.Name).ToListAsync(),
        //        TypeComplaints = await _context.TypeComplaints.OrderBy(n => n.Type).ToListAsync(),

        //    };

        //    return response;

        //}

        public Task IncreamentComplaintSolutionsCount(int id)
        {
            throw new NotImplementedException();
        }



        //public async Task<IEnumerable<Beneficiarie>> GetAllBenficiareByLocalAsync() => await _context.Set<Beneficiarie>().ToListAsync();


        //public async Task<IEnumerable<Beneficiarie>> GetAllBenficiareAsync(params Expression<Func<Beneficiarie, object>>[] includeproperties)
        //{
        //    IQueryable<Beneficiarie> query = _context.Set<Beneficiarie>();
        //    query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
        //    return await query.ToListAsync();
        //}

        //public async Task<IEnumerable<Compalint>> GetAllCompalintsAsync() => await _context.Set<Compalint>().ToListAsync();


        //public async Task<IEnumerable<Compalint>> GetAllCompalintsByLocalAsync(params Expression<Func<Compalint, object>>[] includeproperties)
        //{
        //    IQueryable<Compalint> query = _context.Set<Compalint>();
        //    query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
        //    return await query.ToListAsync();
        //}


    }
}
