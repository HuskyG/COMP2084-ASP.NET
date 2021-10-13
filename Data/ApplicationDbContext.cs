using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Chravel.Models;

namespace Chravel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Make global references
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<DailySchedule> DailySchedules { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<TripSchedule> TripSchedules { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
