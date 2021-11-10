using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.ViewModels
{
    public class LectorNaamId
    {
        public LectorNaamId(Lector l)
        {
            LectorId = l.LectorId;
            Naam = l.Gebruiker.Naam;
            VoorNaam = l.Gebruiker.Voornaam;
        }

        public int LectorId { get; set; }
        public string Naam { get; set; }
        public string VoorNaam { get; set; }
        public string FullName { get => $"{VoorNaam} {Naam}"; }
    }
}
