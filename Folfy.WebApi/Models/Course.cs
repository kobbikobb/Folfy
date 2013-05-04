using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Folfy.WebApi.Models
{
    public class Course : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [IgnoreDataMember]
        public List<Scorecard> Scorecards { get; set; }

        public List<CourseHole> Holes { get; set; } 
    }
}