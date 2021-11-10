using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Data
{
    public class Client
    {
        public Client()
        {
            ClientId = -1;
            ClientName = string.Empty;
            LocationId = -1;
        }
        public Client(int id, string naam, int locatieId)
        {
            ClientId = id;
            ClientName = naam;
            LocationId = locatieId;
        }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int LocationId { get; set; }
        public bool ClientIsValidated => (ClientId > -1);
    }
}
