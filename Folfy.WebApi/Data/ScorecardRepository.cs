using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Folfy.WebApi.Models;
using Folfy.WebApi.Models.Data;


namespace Folfy.WebApi.Data
{
    public class ScorecardRepository : GenericRepository<Scorecard>
    {
        protected override IQueryable<Scorecard> Set
        {
            get
            {
                return base.Set.Include(x=>x.Holes).Include(x => x.Course).Include(x=>x.Owner);
            }
        }
    }
}