using ComplantSystem.Areas.AdminGeneralFederation.Service;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        private readonly ICompalintService _compService;
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
            ICompalintService compService,
            ISolveCompalintService solveCompalintService,

            IWebHostEnvironment env,
           
            AppCompalintsContextDB context)
        {
            this.governorate = governorate;
            this.directorate = directorate;
            this.subDirectorate = subDirectorate;
            this.village = village;
            _compService = compService;
            this.solveCompalintService = solveCompalintService;
            _service = service;
            _context = context;
            _env = env;
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
            var compalintDropdownsData = await _compService.GetNewCompalintsDropdownsValues();
            //var LocationDropdownsData = await _service.GetSelectLocationDropdownsValues();
            var allCompalintsVewi = await _compService.GetAllAsync();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.Status = ViewBag.StatusCompalints;
            int totalCompalints = allCompalintsVewi.Count();
            ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(allCompalintsVewi);
        }


        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var compalintDetails = await _compService.FindAsync(id);
            return View(compalintDetails);
        }



        public async Task<IActionResult> ViewRejectedComplaints()
        {

            var compalintDropdownsData = await _compService.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;

            var rejectedComplaints = await _compService.GetAllAsync(n => n.StatusCompalint);
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
            var selectedCategory = await _compService.GetByIdAsync(id);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSolution(string id, CompalintSolutionVM data)
        {
            CompalintSolutionVM compAndSolution = new CompalintSolutionVM();
            if (id == null) return View("Emoty");
            if (id != data.UploadsComplainte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    var UploadsComplainte = await _context.UploadsComplaintes.FindAsync(id);
                    compAndSolution.UploadsComplainte = UploadsComplainte;
                    //var comp_Solution = await _context.Compalints_Solutions.FindAsync(id);
                    //if (comp_Solution == null) return View("Emoty");



                    await solveCompalintService.UpdateMovieAsync(data);
                    return RedirectToAction(nameof(Index));
                   
                  
               
                }
                return RedirectToAction(nameof(Index));
            }

          
            

           
        

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
            var selectedFile = await _compService.FindAsync(id);
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
