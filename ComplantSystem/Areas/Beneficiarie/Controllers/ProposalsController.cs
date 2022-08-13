using ComplantSystem.Models;
using ComplantSystem.Models.Benef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.Beneficiarie.Controllers
{
    [Area("Beneficiarie")]
    public class ProposalsController : Controller
    {
        private readonly AppCompalintsContextDB _context;


        public ProposalsController(AppCompalintsContextDB context)
        {
            _context = context;

        }


        public async Task<IEnumerable<Proposal>> GetAllAsync() => await _context.Proposals.ToListAsync();

        public async Task<IActionResult> Index()
        {
            var allProposals = await GetAllAsync();

            return View(allProposals);
        }


        public async Task AddProposalAsync(Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();
        }



        public IActionResult AddProposals()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProposals([Bind("TitileProposal,DescProposal")] Proposal proposal)
        {
            if (!ModelState.IsValid)
            {
                return View(proposal);
            }
            await AddProposalAsync(proposal);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IEnumerable<Proposal>> GetAllProposalsAsync() => await _context.Proposals.ToListAsync();

        public async Task<IActionResult> DetailsProposal(string id)
        {
            var detailsProposal = await GetByProposalIdAsync(id);
            return View(detailsProposal);
        }

        public async Task<Proposal> GetByProposalIdAsync(string id)
        {
            var proposalDetails = await _context.Proposals

                .FirstOrDefaultAsync(p => p.Id == id);
            return proposalDetails;
        }

        //public async Task<IEnumerable<Proposal>> GetAllAsync(params Expression<Func<Proposal, object>>[] includeproperties)
        //{
        //    IQueryable<Proposal> query = _context.Proposals;
        //    query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
        //    return await query.ToListAsync();
        //}

    }
}

