using AutoMapper;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Data.Base
{
    public class CompalintRepository : EntityBaseRepository<UploadsComplainte>, ICompalintRepository
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public CompalintRepository(AppCompalintsContextDB context, IMapper mapper, IWebHostEnvironment env) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _env = env;

        }






        public async Task<IEnumerable<UploadsComplainte>> GetAllRejectedComplaints() => await _context.UploadsComplaintes.ToListAsync();

        public Task GetAllGategoryCompAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdatedbCompAsync(UploadsComplainte data)
        {
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbComp != null)
            {

                dbComp.Id = data.Id;
                dbComp.StagesComplaintId = 2;


                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }

        public IQueryable<UploadsComplainte> Search(string term)
        {
            var result = _context.UploadsComplaintes.Where(
                u => u.TitleComplaint == term
                || u.DescComplaint == term);
            return result;
        }





        public Task UpdateAsync(string id, TypeComplaint typeComplaint)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UploadsComplainte> GetAll()
        {
            var result = _context.UploadsComplaintes
                 .OrderByDescending(u => u.UploadDate);

            return result;
        }


        public IQueryable<UploadsComplainte> GetBy(string userId)
        {
            var result = _context.UploadsComplaintes.Where(u => u.UserId == userId)
                .OrderByDescending(u => u.UploadDate)
                .Include(s => s.StatusCompalint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorates)
                .Include(d => d.Directorates)
                .Include(su => su.SubDirectorates);

            return result;
        }

        public async Task<UploadsComplainte> GetCompalintById(string id)
        {
            var compalintDetails = _context.UploadsComplaintes
                .Include(s => s.StatusCompalint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorates)
                .Include(d => d.Directorates)
                .Include(su => su.SubDirectorates)
                .Include(v => v.Villages)
                .Include(st => st.StagesComplaint)
                //.Include(so => so.HoUser.UserName)
                //.Include(cs => cs.Compalints_Solutions)
                //.ThenInclude(a => a.UserAddSolution)
                .FirstOrDefaultAsync(c => c.Id == id);
            //var compalintDetails = from m in _context.UploadsComplainte select m;
            return await compalintDetails;
        }

        public async Task<UploadsComplainte> FindAsync(string id)
        {
            var selectedUpload = await _context.UploadsComplaintes.FindAsync(id);
            if (selectedUpload != null)
            {
                //AutoMapper 
                var compalintDetails = _context.UploadsComplaintes
                .Include(s => s.StatusCompalint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorates)
                .Include(d => d.Directorates)
                .Include(su => su.SubDirectorates)
                .Include(v => v.Villages)
                .Include(st => st.StagesComplaint)
                //.Include(so => so.HoUser.UserName)
                //.Include(cs => cs.Compalints_Solutions)
                //.ThenInclude(a => a.UserAddSolution)
                .FirstOrDefaultAsync(c => c.Id == id);
                //var compalintDetails = from m in _context.UploadsComplainte select m;
                return await compalintDetails;
            }
            return null;
        }

        public async Task CreateAsync2(InputCompmallintVM model)
        {
            var mappedObj = _mapper.Map<UploadsComplainte>(model);
            await _context.UploadsComplaintes.AddAsync(mappedObj);
            await _context.SaveChangesAsync();
        }

        public Task<UploadsComplainte> FindAsync(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task AddSolutionForCompalint(UploadsComplainte data)
        {
            throw new NotImplementedException();
        }

    }
}
