using ApplicationLayer.Property.GetProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Property.Models
{
    public sealed class Properties
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public List<string> Features { get; set; }
        public List<string> Highlights { get; set; }
        public List<Transportation> Transportation { get; set; }
        public List<Space> Spaces
        {
            get; set;
        }
    }
}
