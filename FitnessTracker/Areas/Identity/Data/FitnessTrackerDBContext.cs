using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data
{
    public class FitnessTrackerDBContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Excercise> Exercises { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }

        public DbSet<User> Users { get; set; }

        public FitnessTrackerDBContext(DbContextOptions<FitnessTrackerDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
