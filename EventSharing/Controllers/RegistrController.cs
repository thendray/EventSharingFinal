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
    public class RegistrController : Controller
    {
        private MyAppDbContext db;

        public RegistrController(MyAppDbContext context)
        {
            db = context;
        }
        public IActionResult Registration()
        {
            
            ViewBag.Title = "Registration";
            return View();
        }


        [HttpPost]
        public IActionResult Registration(User user1)
        {
            
            if (string.IsNullOrEmpty(user1.Name))
            {
                ModelState.AddModelError(nameof(user1.Name), "Введите имя");
            }

            if (string.IsNullOrEmpty(user1.Login))
            {
                ModelState.AddModelError(nameof(user1.Login), "Введите логин");
            }

            else if (db.Users.Count(x => x.Login == user1.Login) > 0 )
            {
                ModelState.AddModelError(nameof(user1.Login), "Введенный логин занят");
            }

            if (string.IsNullOrEmpty(user1.Password))
            {
                ModelState.AddModelError(nameof(user1.Password), "Введите пароль");
            }

            if (string.IsNullOrEmpty(user1.PasswordConfirm))
            {
                ModelState.AddModelError(nameof(user1.PasswordConfirm), "Подтвердите пароль");
            }

            if (user1.Password != user1.PasswordConfirm)
            {
                ModelState.AddModelError(nameof(user1.PasswordConfirm), "Пароли не совпадают");
            }

            if (string.IsNullOrEmpty(user1.Email))
            {
                ModelState.AddModelError(nameof(user1.Email), "Введите почту");
            }

            if (ModelState.IsValid)
            {
                user1.QuantityEventsLoad = 0;
                /*user1.Password = */
                db.Users.Add(user1);
                db.SaveChanges();

                CurentUser.CurentUserInfo = db.Users.Where(x => x.Login == user1.Login).First();
                CurentUser.CurentLogInUserId = CurentUser.CurentUserInfo.UserId;
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View(user1);
            }
        }

    }
}
