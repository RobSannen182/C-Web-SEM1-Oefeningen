using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        [Required]
        [DisplayName("Naam")]
        public string GuestName { get; set; }

        public ICollection<GuestParty> GuestParties { get; set; }

    }
}
