﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSharing.Controllers;
using EventSharing.Data;

namespace EventSharing.Models
{
    public class CurentUser
    {
        public static int CurentId = 0;

        public static int CurentLogInUserId = 0;

        public static User CurentUserInfo;

        

        public static bool UserInBase(User user, MyAppDbContext db)
        {
            var myUser = db.Users.Where(x => (x.Login == user.Login && x.Password == user.Password));
            if (myUser.Count()> 0)
            {
                CurentLogInUserId = myUser.First().UserId;
                CurentUserInfo = myUser.First();
                return true;
            }
            return false;
        }
    }
}
