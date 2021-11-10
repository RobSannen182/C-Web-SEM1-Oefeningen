using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTagHelper.Models
{
    public class Land
    {
        public int LandId { get; set; }
        public string LandCode { get; set; }
        public string LandNaam { get; set; }
        public ICollection<Locatie> Locaties { get; set; }
    }
}
