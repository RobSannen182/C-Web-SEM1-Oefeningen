using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.ViewModels
{
    public class VakLectorNaam
    {
        public VakLectorNaam(VakLector vl)
        {
            VakLectorId = vl.VaklectorId;
            VLectorNaam = vl.Lector.Gebruiker.Naam;
            VLectorVoorNaam = vl.Lector.Gebruiker.Voornaam;
        }
        public int VakLectorId { get; set; }
        public string VLectorVoorNaam { get; set; }
        public string VLectorNaam { get; set; }
        public string VLectorFullName { get => $"{VLectorVoorNaam} {VLectorNaam}"; }
    }
}
