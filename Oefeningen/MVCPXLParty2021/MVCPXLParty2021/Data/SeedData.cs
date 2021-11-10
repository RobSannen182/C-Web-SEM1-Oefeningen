using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MVCPXLParty2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PartyDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PartyDbContext>();

            if (!context.Parties.Any())
            {
                Guest g = new Guest { GuestName = "Rob" };
                context.Guests.AddRange(g);
                Location l = new Location { City = "Lommel" };
                context.Locations.AddRange(l);
                Party p = new Party { PartyName = "Fiddle", PartyDate = Convert.ToDateTime("25/09/2022"), LocationId = 1 };
                context.Parties.AddRange(p);
                context.SaveChanges();
            }
        }


    }
}
