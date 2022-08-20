using ComplantSystem.Areas.AdminGeneralFederation.Service;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.AdminGeneralFederation.Controllers
{
    [Area("AdminGeneralFederation")]
    public class ContentManagementsGeneralFederationController : Controller
    {
        private readonly ILocationRepo<Governorate> governorate;
        private readonly ILocationRepo<Directorate> directorate;
        private readonly ILocationRepo<SubDirectorate> subDirectorate;
        private readonly ILocationRepo<Village> village;
        private readonly ICompalintRepository _compReop;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISolveCompalintService solveCompalintService;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public ContentManagementsGeneralFederationController(
            ILocationRepo<Governorate> governorate,
            ILocationRepo<Directorate> directorate,
            ILocationRepo<SubDirectorate> subDirectorate,
            ILocationRepo<Village> village,
            ICategoryService service,
            ICompalintRepository compReop,
            UserManager<ApplicationUser> userManager,
            ISolveCompalintService solveCompalintService,

            IWebHostEnvironment env,

            AppCompalintsContextDB context)
        {
            this.governorate = governorate;
            this.directorate = directorate;
            this.subDirectorate = subDirectorate;
            this.village = village;
            _compReop = compReop;
            this.userManager = userManager;
            this.solveCompalintService = solveCompalintService;
            _service = service;
            _context = context;
            _env = env;

        }


        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }


        public async Task<IActionResult> ReportManagement()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> AllComplaints(int? page)
        {

            var currentUser = await userManager.GetUserAsync(User);
            //var Gov = currentUser?.Governorates.Id;


            var allCompalintsVewi = await _compReop.GetAllAsync(g => g.Governorates);
            var compBy = allCompalintsVewi.Where(g => g.Governorates.Id == currentUser.GovernorateId
            && g.StatusCompalint.Id == 1 && g.StagesComplaintId == 1);
            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.Status = ViewBag.StatusCompalints;
            int totalCompalints = compBy.Count();
            ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(compBy);
        }


        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var compalintDetails = await _compReop.FindAsync(id);
            return View(compalintDetails);
        }

        public async Task<IActionResult> UpCompalint(string id, UploadsComplainte complainte)
        {
            var upComp = await _compReop.FindAsync(id);
            if (upComp == null) return View("Empty");

            var response = new UploadsComplainte()
            {
                Id = complainte.Id,
                StagesComplaintId = 2,
            };
            await _compReop.UpdatedbCompAsync(complainte);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllComplaints));

        }


        public async Task<IActionResult> ViewRejectedComplaints()
        {

            var compalintDropdownsData = await _compReop.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;

            var rejectedComplaints = await _compReop.GetAllAsync(n => n.StatusCompalint);
            var result = rejectedComplaints.Where(n => n.StatusCompalint.Name == "مرفوضة"
            );

            return View(result);

        }

        public async Task<IActionResult> AllCategoriesCommunications()
        {

            return View();
        }

        public async Task<IActionResult> AllCategoriesComplaints()
        {
            var allCategoriesComplaints = await _service.GetAllGategoryCompAsync();

            return View(allCategoriesComplaints);
        }


        public IActionResult AllCirculars()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([Bind("Type")] TypeComplaint typeComplaint)
        {
            if (!ModelState.IsValid)
            {
                return View(typeComplaint);
            }
            await _context.TypeComplaints.AddAsync(typeComplaint);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllCategoriesComplaints));

        }

        //Get: Category/Edit/1
        public async Task<IActionResult> EditCategoryComplaint(string id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null) return View("Empty");
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategoryComplaint(string id, [Bind("Id,Type")] TypeComplaint typeComplaint)
        {
            if (!ModelState.IsValid)
            {
                return View(typeComplaint);
            }
            await _service.UpdateAsync(id, typeComplaint);
            return RedirectToAction(nameof(AllCategoriesComplaints));
        }
        //Get: Category/Delete/1
        public async Task<IActionResult> DeleteCategoryComplainty(string id)
        {
            var selectedCategory = await _compReop.GetByIdAsync(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }


            return View(selectedCategory);

        }

        [HttpPost]
        [ActionName("DeleteCategoryComplainty")]
        public async Task<IActionResult> DeleteConfirmedCategoryComplaint(string id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Empty");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(AllCategoriesComplaints));
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddSolution(string id, UploadsComplainte data)
        //{

        //    if (id == null) return View("Emoty");
        //    if (id != data.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        var AddSolutionComplainte = await _context.UploadsComplaintes.FindAsync(id);
        //        var newSolution = new Compalints_Solution()
        //        {
        //            ContentSolution = ,

        //        };
        //        await _context.AddAsync(newSolution);
        //        await _context.SaveChangesAsync();

        //        // Add Movie Actor 

        //        foreach (var Users in data.UsersIds)
        //        {

        //            var newComplaintSolution = new Compalints_Solution()
        //            {
        //                CompalintId = newSolution.Id,
        //                UserId = UserId,
        //            };
        //            await _context.Compalints_Solutions.AddAsync(newComplaintSolution);
        //        }
        //        await _context.SaveChangesAsync();


        //        return RedirectToAction(nameof(AllComplaints));



        //    }
        //    return null;
        //}







        public async Task<IActionResult> DetailsCategoriesComplaints(string id)
        {
            var categorieDetails = await _service.GetByIdAsync(id);
            if (categorieDetails == null)
            {
                return View("Empty");

            }
            return View(categorieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await _compReop.FindAsync(id);
            if (selectedFile == null)
            {
                return NotFound();
            }

            //await _compService.IncreamentDownloadCount(id);

            var path = "~/Uploads/" + selectedFile.FileName;
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");
            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);
        }


    }



}
