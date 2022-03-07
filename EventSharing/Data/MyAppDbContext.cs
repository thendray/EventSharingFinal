using EventSharing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace EventSharing.Data
{
    public class MyAppDbContext : DbContext
    {
        public static MyAppDbContext DB { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

    }
}
