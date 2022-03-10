using EventSharing.Data;
using EventSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Controllers
{
    public class SearchMapController : Controller
    {
        private MyAppDbContext db;
        public SearchMapController(MyAppDbContext context)
        {
            db = context;
        }
        public IActionResult Map()
        {
            ViewBag.Title = "Search Event";
            ViewBag.Count = 0;
            
            return View();
        }


        [HttpPost]
        public IActionResult Map(MapInfo map)
        {
            if (string.IsNullOrEmpty(map.Name))
            {
                ModelState.AddModelError(nameof(map.Name), "Вы ничего не ввели");
            }
            if (CurentEvent.EventsInBase(map, db) == false)
            {
                ModelState.AddModelError(nameof(map.Name), "По вашему запросу ничего не найдено");
            }
            else
            {
                CurentEvent.Names = CurentEvent.FindEvents.Select(x => x.Name).ToList();
                CurentEvent.Adresses = CurentEvent.FindEvents.Select(x => x.Adress).ToList();
                CurentEvent.StartsTime = CurentEvent.FindEvents.Select(x => (x.StartTime).ToString("d")).ToList();
                CurentEvent.HourDurations = CurentEvent.FindEvents.Select(x => (x.EndTime - x.StartTime).TotalHours.ToString("f2")).ToList();
                CurentEvent.Informations = CurentEvent.FindEvents.Select(x => x.EventType).ToList();
            }
            if (ModelState.IsValid)
            {
                
                ViewBag.Count = CurentEvent.Names.Count;
                
                return View();
            }
            else
            {
                ViewBag.Count = 0;
                return View(map);
            }
        }
    }

    

}
