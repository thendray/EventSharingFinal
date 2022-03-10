using EventSharing.Data;
using EventSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Controllers
{
    public class PostController : Controller
    {
        private MyAppDbContext db;
        public PostController(MyAppDbContext context)
        {
            db = context;
        }
        public IActionResult Post()
        {
            ViewBag.Title = "Post Event";
            ViewBag.IsPosted = false;
            return View();
        }

        [HttpPost]
        public IActionResult Post(Event event1)
        {
            ViewBag.Title = "Post Event";
            if (string.IsNullOrEmpty(event1.Name))
            {
                ModelState.AddModelError(nameof(event1.Name), "Введите название");
            }

            if (string.IsNullOrEmpty(event1.Adress))
            {
                ModelState.AddModelError(nameof(event1.Adress), "Введите адрес");
            }

            if (event1.StartTime == default)
            {
                ModelState.AddModelError(nameof(event1.StartTime), "Введите дату и время начала");
            }

            if (event1.EndTime == default)
            {
                ModelState.AddModelError(nameof(event1.EndTime), "Введите дату и время окончания");
            }

            if (event1.EndTime < event1.StartTime)
            {
                ModelState.AddModelError(nameof(event1.EndTime), "Дата окончания не может быть раньше даты начала");
            }

            if (string.IsNullOrEmpty(event1.EventType))
            {
                ModelState.AddModelError(nameof(event1.EventType), "Введите краткую информацию");
            }

            if (ModelState.IsValid)
            {
                CurentUser.CurentUserInfo.QuantityEventsLoad += 1;
                db.Users.Where(x => x == CurentUser.CurentUserInfo).First().QuantityEventsLoad = CurentUser.CurentUserInfo.QuantityEventsLoad;
                event1.UserId = CurentUser.CurentUserInfo.UserId;
                db.Events.Add(event1);
                db.SaveChanges();
                ViewBag.IsPosted = true;
                return View(event1);
            }
            else
            {
                return View(event1);
            }

        }
    }
}
