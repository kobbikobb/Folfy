using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Folfy.WebApi.Models;
using Folfy.WebApi.Models.Data;

namespace Folfy.WebApi.Data
{
    public class HoleRepository : GenericRepository<Hole>
    {
        protected override IQueryable<Hole> Set
        {
            get
            {
                return base.Set.Include(x => x.Player);
            }
        }
    }
}