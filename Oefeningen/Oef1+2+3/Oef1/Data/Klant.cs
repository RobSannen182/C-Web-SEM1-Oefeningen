using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef1.Data
{
    public class Klant
    {
        public Klant()
        {
            KlantId = -1;
            KlantNaam = string.Empty;
            LocationId = -1;
        }

        public Klant(int id, string naam, int locId)
        {
            KlantId = id;
            KlantNaam = naam;
            LocationId = locId;
        }

        public int KlantId { get; set; }
        public string KlantNaam { get; set; }
        public int LocationId { get; set; }
        public bool GevalideerdeKlant => (KlantId > -1);
    }
}
