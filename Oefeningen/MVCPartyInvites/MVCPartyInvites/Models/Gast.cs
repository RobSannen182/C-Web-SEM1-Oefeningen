using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPartyInvites.Models
{
    public class Gast
    {
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public bool? Aanwezig { get; set; }
    }
}
