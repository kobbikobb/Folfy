using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Folfy.WebApi.Models;

namespace Folfy.WebApi.Data
{
    public class FolfyDbContext : DbContext
    {
        public FolfyDbContext(): base("name=FolfyDbContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseHole> CourseHoles { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Scorecard> Scorecards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}