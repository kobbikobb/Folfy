using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folfy.WebApi.Models
{
    public class Scorecard : IModel
    {
        public int Id { get; set; }
        public User Owner { get; set; }

        public Course Course { get; set; }

        public List<Hole> Holes { get; set; }
    }
}