using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Folfy.WebApi.Models;

namespace Folfy.WebApi.Data
{
    public class CourseRepository : GenericRepository<Course>
    {
        protected override IQueryable<Course> Set
        {
            get
            {
                return base.Set.Include(x => x.Holes);
            }
        }
    }
}