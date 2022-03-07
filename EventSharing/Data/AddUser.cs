using EventSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Data
{
    public class AddUser
    {
        public static void AddNewUser(MyAppDbContext context, User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
