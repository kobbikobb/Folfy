using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Folfy.WebApi.Models
{
    public class CourseHole : IModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
     
        [IgnoreDataMember]
        public Course Course { get; set; }
    }
}