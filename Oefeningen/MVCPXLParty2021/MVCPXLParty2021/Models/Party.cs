using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Models
{
    public class Party
    {
        public int PartyId { get; set; }
        [Required]
        [DisplayName("Party Naam")]
        public string PartyName { get; set; }
        [Required]
        [DisplayName("Datum")]
        [Column(TypeName = "Date")]
        public DateTime PartyDate { get; set; }
        [Required]
        [DisplayName("Locatie")]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<GuestParty> GuestParties { get; set; }
    }
}
