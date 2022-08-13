using ComplantSystem.Areas.VillagesUsers.Service;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ComplantSystem.Models;

namespace ComplantSystem.Areas.VillagesUsers.Controllers
{
    [Area("VillagesUsers")]
    public class VillagesController : Controller
    {
        private readonly ILocationRepo<Governorate> governorate;
        private readonly ILocationRepo<Directorate> directorate;
        private readonly ILocationRepo<SubDirectorate> subDirectorate;
        private readonly ILocationRepo<Village> village;

        private readonly IVillageService _service;


        public VillagesController(ILocationRepo<Governorate> governorate, ILocationRepo<Directorate> directorate, ILocationRepo<SubDirectorate> subDirectorate, ILocationRepo<Village> village, IVillageService service)
        {
            this.governorate = governorate;
            this.directorate = directorate;
            this.subDirectorate = subDirectorate;
            this.village = village;
            _service = service;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            //var LocationDropdownsData = await _service.GetSelectLocationDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            var allCompalintsVewi = await _service.GetAllAsync();
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            };

            int limit = 4;
            int start = (int)((page - 1) * limit);
            int totalCompalints = allCompalintsVewi.Count();
            ViewBag.TotalCompalints = totalCompalints;
            ViewBag.totalCompalints = totalCompalints;
            ViewBag.pageCurrent = page;
            int numberPage = totalCompalints / limit;
            ViewBag.numberPage = numberPage;
            var dataCompalints = allCompalintsVewi.OrderByDescending(s => s.Id).Skip(start).Take(limit);
            return View(dataCompalints);



        }

        public async Task<IActionResult> ViewUserInfo(string id)
        {
            var UserInfo = await _service.GetByIdAsync(id);
            return View(UserInfo);
        }
        public async Task<IActionResult> ViewAllBeneficiarie(int? page)
        {
            var compalintDropdownsData = await _service.GetAllBenficiareByLocalAsync();

            var allBenficiareView = await _service.GetAllBenficiareByLocalAsync();
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            };

            int limit = 4;
            int start = (int)((page - 1) * limit);
            int totalCompalints = allBenficiareView.Count();
            ViewBag.TotalCompalints = totalCompalints;
            ViewBag.totalCompalints = totalCompalints;
            ViewBag.pageCurrent = page;
            int numberPage = totalCompalints / limit;
            ViewBag.numberPage = numberPage;
            var dataCompalints = allBenficiareView.OrderByDescending(s => s.Id).Skip(start).Take(limit);
            return View(dataCompalints);
        }


        [HttpGet]
        public JsonResult GetDirectorates(int GovernorateId)
        {
            var g = governorate.Find(GovernorateId);
            var dire = directorate.ListByFilter(cc => cc.Governorate == g);
            return Json(new SelectList(dire, "Id", "Name"));
        }




        //GET Compalint/ViewCompalintDetails/1

        public async Task<IActionResult> ViewCompalintDetails(string id)
        {
            var compalintDetails = await _service.GetByIdAsync(id);
            return View(compalintDetails);
        }


        [AllowAnonymous]
        public async Task<IActionResult> FilterCompalintsBySearch(string searchString)
        {
            var allCompalints = await _service.GetAllCompalintsByLocalAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filtterResulteNew = allCompalints.Where(n => string.Equals(n.TitleComplaint,
                    searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.DescComplaint,
                    searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filtterResulteNew);
            }
            //return View("Index", allCompalints);
            return View("Index", allCompalints);
        }
        public IActionResult OrderLimitationUser()
        {
            return View();
        }


        public IActionResult AllCommunication()
        {
            return View();
        }
        public IActionResult AddCommunication()
        {
            return View();
        }

    }
}
