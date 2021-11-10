using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef1.Data
{
    public class Locations
    {
        public Locations()
        {
            LocationId = -1;
            Postcode = string.Empty;
            City = string.Empty; 
        }

        public Locations(int id, string postcode, string city)
        {
            LocationId = id;
            Postcode = postcode;
            City = city;
        }

        public int LocationId { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
    }
}
