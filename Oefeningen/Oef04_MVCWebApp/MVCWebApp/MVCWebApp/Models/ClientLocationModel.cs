using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models
{
    public class ClientLocationModel
    {
        public string KlantName { get; set; }
        public string City { get; set; }

        public ClientLocationModel()
        {
            KlantName = string.Empty;
            City = string.Empty;
        
        }

        public ClientLocationModel(string klantName, string city)
        {
            KlantName = klantName;
            City = city;
        }

        public IEnumerable<ClientLocationModel> Overview()
        {
            var clients = Data.Databank.Clients;
            var locations = Data.Databank.Locations;
            var query = clients.Join(locations, k => k.LocationId, l => l.LocationId,
                (k, l) => new ClientLocationModel { KlantName = k.ClientName, City = l.City });
            return query.ToList();
        }
    }
}
