using Microsoft.EntityFrameworkCore;
using MVCPXLParty2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Data
{
    public class PartyDbContext : DbContext
    {
        public PartyDbContext(DbContextOptions<PartyDbContext>options) : base(options)
        {
        }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestParty> GuestParties { get; set; }

    }
}
