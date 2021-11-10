using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        [DisplayName("Stad")]
        public string City { get; set; }

        public ICollection<Party> Parties { get; set; }
    }
}
