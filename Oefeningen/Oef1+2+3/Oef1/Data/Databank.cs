using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef1.Data
{
    public class Databank
    {
        public static List<Klant> Klanten = new List<Klant>();
        public static List<Locations> Locaties = new List<Locations>();

        public static void StartDatabank()
        {
            Klanten.Add(new Klant(1, "Klant A", 1));
            Klanten.Add(new Klant(2, "Klant B", 2));
            Locaties.Add(new Locations(1, "3920", "Lommel"));
            Locaties.Add(new Locations(2, "3900", "Pelt"));
        }

        public static void AddLocatie(string postcode, string city)
        {
            var id = Locaties.Max(x => x.LocationId);
            Locaties.Add(new Locations(id + 1, postcode, city));
        }

        public static void AddKlant(string naam, int locId)
        {
            var id = Klanten.Max(x => x.KlantId);
            Klanten.Add(new Klant(id + 1, naam, locId));
        }

    }
}
