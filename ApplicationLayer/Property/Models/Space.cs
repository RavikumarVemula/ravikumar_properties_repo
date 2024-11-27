using ApplicationLayer.Property.GetProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Property.Models
{
    public sealed class Space
    {
        public string SpaceId { get; set; }
        public string SpaceName { get; set; }
        public List<RentRoll> RentRoll { get; set; }
    }
}
