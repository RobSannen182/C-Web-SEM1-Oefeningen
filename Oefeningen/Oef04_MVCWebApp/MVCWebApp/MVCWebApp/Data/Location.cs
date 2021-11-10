using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Data
{
    public class Location
    {
        public Location()
        {
            LocationId = -1;
            PostCode = string.Empty;
            City = string.Empty;
        }
        public Location(int locationId, string postCode, string city)
        {
            LocationId = locationId;
            PostCode = postCode;
            City = city;
        }
        public int LocationId { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}
