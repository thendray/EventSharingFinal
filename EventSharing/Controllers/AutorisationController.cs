using EventSharing.Data;
using EventSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Controllers
{
    public class AutorisationController : Controller
    {
        private MyAppDbContext db;
        public AutorisationController(MyAppDbContext context)
        {
            db = context;
        }

        public IActionResult Autorisation()
        {
            ViewBag.Title = "Autorisation";

            return View();
        }

        [HttpPost]
        public IActionResult Autorisation(User user1)
        {

            if (string.IsNullOrEmpty(user1.Login))
            {
                ModelState.AddModelError(nameof(user1.Login), "Введите логин");
            }

            if (string.IsNullOrEmpty(user1.Password))
            {
                ModelState.AddModelError(nameof(user1.Password), "Введите пароль");
            }

            if (!CurentUser.UserInBase(user1, db))
            {
                ModelState.AddModelError(nameof(user1.Password), "Не верно введен логин или пароль");
            }

            if ( CurentUser.CurentLogInUserId == 0 )
            {
                ModelState.AddModelError(nameof(user1.Password), "Пользователя с таким логином и паролем не существует");
            }

            if (ModelState.IsValid)
            {

                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View(user1);
            }
        }
    }
}
