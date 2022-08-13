using AutoMapper;
using ComplantSystem.Areas.AdminGeneralFederation.Service;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Models.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Areas

{
    public class SolveCompalintService : ISolveCompalintService
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;

     

        public SolveCompalintService(AppCompalintsContextDB context, IMapper mapper, IWebHostEnvironment env) 
        {
            _context = context;
            this.mapper = mapper;
            this.env = env;
        }

        public async Task UpdateMovieAsync(CompalintSolutionVM data)
        {
            var dbSolotionCompalint = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == data.Compalints_Solution.Id);
            if (dbSolotionCompalint != null)
            {
                foreach (var userId in data.UploadsComplainte.SolutionsCompalints)
                {

                    var newSolotion = new Compalints_Solution()
                    {
                        CompalintId = data.UploadsComplainte.Id,
                        UserId = userId.ToString(),
                        ContentSolution = data.Compalints_Solution.ContentSolution,
                    };

                    await _context.Compalints_Solutions.AddAsync(newSolotion);
                }
                await _context.SaveChangesAsync();





                await _context.SaveChangesAsync();
            }

        }
    
}
}
