using AutoMapper;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ComplantSystem
{
    public class CompalintService : EntityBaseRepository<UploadsComplainte>, ICompalintService
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CompalintService(AppCompalintsContextDB context, IMapper mapper, IWebHostEnvironment env) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }



        //public async Task AddNewCompalintAsync(NewCompalintVM data)
        //{


        //    var addCompalintmappedObj = new Compalint()
        //    {
        //        TitleComplaint = data.TitleComplaint,
        //        TypeComplaintId = data.TypeComplaintId,
        //        DescComplaint = data.DescComplaint,
        //        PropBeneficiarie = data.PropBeneficiarie,
        //        GovernorateId = data.GovernorateId,
        //        DirectorateId = data.DirectorateId,
        //        SubDirectorateId = data.SubDirectorateId,
        //        VillageId = data.VillageId,
        //        StagesComplaintId= data.StagesComplaintId = 1,

        //    };


        //    await _context.AddAsync(addCompalintmappedObj);
        //    await _context.SaveChangesAsync();

        //    //await _context.SaveChangesAsync();


        //}



        public async Task<IEnumerable<UploadsComplainte>> GetAllRejectedComplaints() => await _context.UploadsComplaintes.ToListAsync();

        public Task GetAllGategoryCompAsync()
        {
            throw new NotImplementedException();
        }





        public Task DeleteAsync(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task IncreamentDownloadCount(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUploadsCount()
        {
            throw new NotImplementedException();
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

        public async Task CreateAsync(InputCompmallintVM data)
        {


            var newName = Guid.NewGuid().ToString(); //rre-rewrwerwer-gwgrg-grgr
            var extension = Path.GetExtension(data.File.FileName);
            var fileName = string.Concat(newName, extension); // newName + extension
            var root = _env.WebRootPath;
            var path = Path.Combine(root, "Uploads", fileName);

            using (var fs = System.IO.File.Create(path))
            {
                await data.File.CopyToAsync(fs);
            }

            var addCompalintmappedObj = new UploadsComplainte()
            {
                TitleComplaint = data.TitleComplaint,
                TypeComplaintId = data.TypeComplaintId,
                DescComplaint = data.DescComplaint,
                PropBeneficiarie = data.PropBeneficiarie,
                GovernorateId = data.GovernorateId,
                DirectorateId = data.DirectorateId,
                SubDirectorateId = data.SubDirectorateId,
                VillageId = data.VillageId,
                StagesComplaintId = data.StagesComplaintId = 1,
                OriginalFileName = data.File.FileName,
                FileName = fileName,
                ContentType = data.File.ContentType,
                Size = data.File.Length,


            };




            //var mappedObj = _mapper.Map<UploadsComplainte>(addCompalintmappedObj);
            await _context.UploadsComplaintes.AddAsync(addCompalintmappedObj);
            await _context.SaveChangesAsync();
        }

        IQueryable<UploadsComplainte> ICompalintService.GetAll()
        {
            var result = _context.UploadsComplaintes
                .OrderByDescending(u => u.UploadDate);
            //.ProjectTo<UploadsComplainte>(_mapper.ConfigurationProvider);
            return result;
        }

        public IQueryable<UploadsComplainte> GetBy(string userId)
        {
            var result = _context.UploadsComplaintes.Where(u => u.UserId == userId)
                .OrderByDescending(u => u.UploadDate);
            //.ProjectTo<UploadsComplainte>(_mapper.ConfigurationProvider);
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
    }
}
