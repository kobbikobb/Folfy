using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Folfy.WebApi.Models
{
    public class Hole : IModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Score { get; set; }

        [IgnoreDataMember]
        public Scorecard Scorecard { get; set; }
        public User Player { get; set; }
    }
}