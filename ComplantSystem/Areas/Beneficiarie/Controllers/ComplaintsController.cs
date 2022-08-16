using ComplantSystem.Areas.Beneficiarie.ViewModels;
using ComplantSystem.Const;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem.Areas.Beneficiarie.Controllers
{
    [Area("Beneficiarie")]

    [Authorize(UserRoles.AdminVillages)]

    public class ComplaintsController : Controller
    {
        private readonly ILocationRepo<Governorate> governorate;
        private readonly ILocationRepo<Directorate> directorate;
        private readonly ILocationRepo<SubDirectorate> subDirectorate;
        private readonly ILocationRepo<Village> village;

        private readonly IWebHostEnvironment _env;


        private readonly ICompalintService _service;
        private readonly AppCompalintsContextDB _context;

        public ComplaintsController(
            ILocationRepo<Governorate> governorate,
            ILocationRepo<Directorate> directorate,
            ILocationRepo<SubDirectorate> subDirectorate,
            ILocationRepo<Village> village,
            ICompalintService service,
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



       



        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            //var LocationDropdownsData = await _service.GetSelectLocationDropdownsValues();
            var result = _service.GetBy(UserId);
            //var model = await GetPagedData(result, requiredPage);
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.Status = ViewBag.StatusCompalints;

            int totalCompalints = result.Count();
          
            ViewBag.totalCompalints = totalCompalints;

            return View(result.ToList());
        }



        //private async Task<List<UploadsComplainte>> GetPagedData(IQueryable<UploadsComplainte> result, int requiredPage = 1)
        //{
        //    const int pageSize = 3;
        //    decimal rowsCount = await _service.GetAllCount();

        //    var pagesCount = Math.Ceiling(rowsCount / pageSize);

        //    if (requiredPage > pagesCount)
        //    {
        //        requiredPage = 1;
        //    }
        //    if (requiredPage <= 0)
        //    {
        //        requiredPage = 1;
        //    }

        //    int skipCount = (requiredPage - 1) * pageSize;

        //    //select count(*) from Uploads ;
        //    var pagedData = await result
        //        .Skip(skipCount)
        //        .Take(pageSize)
        //        .ToListAsync();
        //    ViewBag.CurrentPage = requiredPage;
        //    ViewBag.PagesCount = pagesCount;

        //    return pagedData;
        //}




        public async Task<IActionResult> ViewRejectedComplaints()
        {
            
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

             ViewBag.status = ViewBag.StatusCompalints;

            var rejectedComplaints = await _service.GetAllAsync(n=> n.StatusCompalint);
            var result =  rejectedComplaints.Where(n => n.StatusCompalint.Name == "مرفوضة"
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



        ////GET: Compalint /Add
        //public async Task<IActionResult> AddCompalint()
        //{
        //    NewCompalintVM NcomVM = new NewCompalintVM()
        //    {
        //        Governorates = governorate.List(),
        //    };
        //    var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

        //    ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
        //    ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");

        //    return View(NcomVM);

        //}


    

       

        //[HttpPost]
        //public async Task<IActionResult> AddCompalint(NewCompalintVM data)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var addCompalint = new Compalint()
        //        {
        //            TitleComplaint = data.TitleComplaint,
        //            TypeComplaintId = data.TypeComplaintId,
        //            DescComplaint = data.DescComplaint,
        //            PropBeneficiarie = data.PropBeneficiarie,
        //            GovernorateId = data.GovernorateId,
        //            DirectorateId = data.DirectorateId,
        //            SubDirectorateId = data.SubDirectorateId,
        //            VillageId = data.VillageId,
        //            CompDate = data.CompDate,


        //        };
        //    }
        //    await _service.AddNewCompalintAsync(data);
        //    return RedirectToAction(nameof(Index));


        //}

        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            InputCompmallintVM NcomVM = new InputCompmallintVM()
            {
                Governorates = governorate.List(),
            };
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");

            return View(NcomVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputCompmallintVM data)
        {
            if (!ModelState.IsValid)
            {
                var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
                ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
                ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
                var newName = Guid.NewGuid().ToString(); //rre-rewrwerwer-gwgrg-grgr
                var extension = Path.GetExtension(data.File.FileName);
                var fileName = string.Concat(newName, extension); // newName + extension
                var root = _env.WebRootPath;
                var path = Path.Combine(root, "Uploads", fileName);

                using (var fs = System.IO.File.Create(path))
                {
                    await data.File.CopyToAsync(fs);
                }


                //await _service.CreateAsync(data);
                await _service.CreateAsync2(new InputCompmallintVM
                {
                    TitleComplaint = data.TitleComplaint,
                    TypeComplaintId = data.TypeComplaintId,
                    DescComplaint = data.DescComplaint,
                    PropBeneficiarie = data.PropBeneficiarie,
                    GovernorateId = data.GovernorateId,
                    DirectorateId = data.DirectorateId,
                    SubDirectorateId = data.SubDirectorateId,
                    VillageId = data.VillageId,
                    UserId = UserId,
                    StagesComplaintId = data.StagesComplaintId = 1,
                    OriginalFileName = data.File.FileName,
                    FileName = fileName,
                    ContentType = data.File.ContentType,
                    Size = data.File.Length,
                }) ; 

                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }





        //[HttpGet]
        //public async Task<IActionResult> Create2()
        //{
        //    InputCompmallintVM NcomVM = new InputCompmallintVM()
        //    {
        //        Governorates = governorate.List(),
        //    };
        //    var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

        //    ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
        //    ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");

        //    return View(NcomVM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create2(InputCompmallintVM data)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
        //        ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
        //        ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");



        //        await _service.CreateAsync(data);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(data);
        //}



        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var compalintDetails = await _service.FindAsync(id);
            return View(compalintDetails);
        }


        [AllowAnonymous]
        public async Task<IActionResult> RejectedComplaints()
        {
            var allCompalints = await _service.GetAllAsync(n =>n.StatusCompalintId == 2);
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
