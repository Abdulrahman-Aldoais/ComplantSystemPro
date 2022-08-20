using ComplantSystem.Const;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.Beneficiarie.Controllers
{
    [Area("Beneficiarie")]

    [Authorize(UserRoles.Beneficiarie)]

    public class ComplaintsController : Controller
    {
        private readonly ILocationRepo<Governorate> governorate;
        private readonly ILocationRepo<Directorate> directorate;
        private readonly ILocationRepo<SubDirectorate> subDirectorate;
        private readonly ILocationRepo<Village> village;

        private readonly ICompalintRepository _service;
        private readonly IWebHostEnvironment _env;



        private readonly AppCompalintsContextDB _context;

        public ComplaintsController(
            ILocationRepo<Governorate> governorate,
            ILocationRepo<Directorate> directorate,
            ILocationRepo<SubDirectorate> subDirectorate,
            ILocationRepo<Village> village,
            ICompalintRepository service,
            IWebHostEnvironment env,
            AppCompalintsContextDB context)
        {
            this.governorate = governorate;
            this.directorate = directorate;
            this.subDirectorate = subDirectorate;
            this.village = village;

            _service = service;
            _context = context;
            _env = env;
        }








        public async Task<IActionResult> Index(
            string currentFilter,
            string searchString,
            int? pageNumber)
        {

            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var result = _service.GetBy(UserId);


            if (!String.IsNullOrEmpty(searchString))
            {

            }

            int totalCompalints = result.Count();

            ViewBag.totalCompalints = totalCompalints;


            int pageSize = 3;



            return View(await PaginatedList<UploadsComplainte>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));

        }



        public async Task<IActionResult> ViewRejectedComplaints()
        {

            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;

            var rejectedComplaints = await _service.GetAllAsync(n => n.StatusCompalint);
            var result = rejectedComplaints.Where(n => n.StatusCompalint.Name == "مرفوضة"
            );

            return View(result.ToList());

        }



        [HttpGet]
        public JsonResult GetDirectorates(int GovernorateId)
        {
            var g = governorate.Find(GovernorateId);
            var dire = directorate.ListByFilter(cc => cc.Governorate == g);
            return Json(new SelectList(dire, "Id", "Name"));
        }

        [HttpGet]
        public JsonResult GetSubDirectorates(int DirectorateId)
        {
            var d = directorate.Find(DirectorateId);
            var subdire = subDirectorate.ListByFilter(cc => cc.Directorate == d);
            return Json(new SelectList(subdire, "Id", "Name"));
        }


        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {


            InputCompmallintVM model = new InputCompmallintVM
            {
                Governorates = governorate.List(),
                Directorates = directorate.List(),
            };

            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputCompmallintVM model)
        {


            if (ModelState.IsValid)
            {

                var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
                ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
                ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
                var newName = Guid.NewGuid().ToString(); //rre-rewrwerwer-gwgrg-grgr
                var extension = Path.GetExtension(model.File.FileName);
                var fileName = string.Concat(newName, extension); // newName + extension
                var root = _env.WebRootPath;
                var path = Path.Combine(root, "Uploads", fileName);

                using (var fs = System.IO.File.Create(path))
                {
                    await model.File.CopyToAsync(fs);
                }


                //await _service.CreateAsync(data);
                await _service.CreateAsync2(new InputCompmallintVM
                {
                    TitleComplaint = model.TitleComplaint,
                    TypeComplaintId = model.TypeComplaintId,
                    DescComplaint = model.DescComplaint,
                    PropBeneficiarie = model.PropBeneficiarie,
                    GovernorateId = model.GovernorateId,
                    DirectorateId = model.DirectorateId,
                    SubDirectorateId = model.SubDirectorateId,
                    VillageId = model.VillageId,
                    UserId = UserId,
                    StagesComplaintId = model.StagesComplaintId = 1,
                    OriginalFileName = model.File.FileName,
                    FileName = fileName,
                    ContentType = model.File.ContentType,
                    Size = model.File.Length,
                });

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }




        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var compalintDetails = await _service.FindAsync(id);
            return View(compalintDetails);
        }


        [AllowAnonymous]
        public async Task<IActionResult> RejectedComplaints()
        {
            var allCompalints = await _service.GetAllAsync(n => n.StatusCompalintId == 2);
            return View(allCompalints);
        }



        [AllowAnonymous]
        public async Task<IActionResult> FilterCompalintsBySearch(string term)
        {
            //var allCompalints = await _service.GetAllAsync();
            //if (!string.IsNullOrEmpty(term))
            //{
            //    var filtterResulteNew = allCompalints.Where(n => string.Equals(n.TitleComplaint,
            //        term, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.DescComplaint,
            //        term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            //    return View("Index", filtterResulteNew);
            //}
            ////return View("Index", allCompalints);
            //return View("Index", allCompalints);

            var allCompalints = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(term))
            {

                var result = _context.UploadsComplaintes.Where(
                 u => u.TitleComplaint == term
                 || u.DescComplaint == term);
                return View("Index", result);
            }
            return View("Index", allCompalints);
            //return result;
        }


        [HttpGet]
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await _service.FindAsync(id);
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
