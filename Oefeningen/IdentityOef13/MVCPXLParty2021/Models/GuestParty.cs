using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Models
{
    public class GuestParty
    {
        public int GuestPartyId { get; set; }
        [Required]
        [DisplayName("Gast")]
        public int GuestId { get; set; }
        [Required]
        [DisplayName("Party")]
        public int PartyId { get; set; }

        public Guest Guest { get; set; }
        public Party Party { get; set; }
    }
}
