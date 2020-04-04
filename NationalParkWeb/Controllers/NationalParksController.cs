using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NationalParkWeb.Models;
using NationalParkWeb.Repository.IRepository;

namespace NationalParkWeb.Controllers
{
    public class NationalParksController : Controller
    {
        private readonly INationalParkRepository _npRepo;

        public NationalParksController(INationalParkRepository npRepo)
        {
            _npRepo = npRepo;
        }
        public IActionResult Index()
        {
            return View(new NationalPark() { });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            NationalPark obj = new NationalPark();

            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //flow will come here for update
            obj = await _npRepo.GetAsync(SD.NationalParkAPIPath, id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }

            return View(new NationalPark() { });
        }

        public async Task<IActionResult> GetAllNationalPark()
        {
            return Json(new { data = await _npRepo.GetAllAsync(SD.NationalParkAPIPath) });
        }
    }
}