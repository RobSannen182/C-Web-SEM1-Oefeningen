using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Data
{
    public class Databank
    {
        public static List<Client> Clients = new List<Client>();
        public static List<Location> Locations = new List<Location>();
        public static void StartDatabank()
        {
            Clients.Add(new Client(1, "Klant A", 1));
            Clients.Add(new Client(2, "Klant B", 2));
            //Locations
            Locations.Add(new Location(1, "3500", "Hasselt"));
            Locations.Add(new Location(2, "3600", "Genk"));
        }
        public static void AddLocation(string postCode, string city)
        {
            int id = Locations.Max(x => x.LocationId) + 1;
            Locations.Add(new Location(id, postCode, city));
        }
        public static void AddKlant(string clientName, int locationId)
        {
            int id = Clients.Max(x => x.ClientId) + 1;
            Clients.Add(new Client(id, clientName, locationId));
        }
    }
}

