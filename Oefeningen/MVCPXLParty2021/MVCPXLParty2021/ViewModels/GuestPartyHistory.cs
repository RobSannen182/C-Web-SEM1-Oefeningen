using Microsoft.EntityFrameworkCore;
using MVCPXLParty2021.Data;
using MVCPXLParty2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.ViewModels
{
    public class GuestPartyHistory
    {
        public GuestPartyHistory(PartyDbContext context, Guest gast)
        {
            GuestId = gast.GuestId;
            GuestName = gast.GuestName;
            PartyHistory = context.GuestParties
                .Include(p => p.Party)
                .ThenInclude(l => l.Location)
                .Where(x => x.GuestId == gast.GuestId && x.Party.PartyDate < DateTime.Now)
                .OrderByDescending(d => d.Party.PartyDate)
                .Take(5)
                .ToList();
            PartyFuture = context.GuestParties
                .Include(p => p.Party)
                .ThenInclude(l => l.Location)
                .Where(x => x.GuestId == gast.GuestId && x.Party.PartyDate >= DateTime.Now)
                .OrderBy(d => d.Party.PartyDate)
                .Take(5)
                .ToList();
        }

        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public List<GuestParty> PartyHistory { get; set; }
        public List<GuestParty> PartyFuture { get; set; }
        
    }
}
