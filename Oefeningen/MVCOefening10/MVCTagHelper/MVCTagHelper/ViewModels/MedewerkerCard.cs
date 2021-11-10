using MVCTagHelper.Data;
using MVCTagHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTagHelper.ViewModels
{
    public class MedewerkerCard
    {
        public MedewerkerCard(Medewerker medewerker)
        {
            MedewerkerId = medewerker.MedewerkerId;
            MedewerkerNaam = $"{medewerker.Voornaam} {medewerker.Naam}";
            AfdelingNaam = medewerker.Afdeling.AfdelingNaam;
            Medewerker = medewerker;
        }

        public Medewerker Medewerker { get; set; }
        public int MedewerkerId { get; set; }
        public string MedewerkerNaam { get; set; }
        public string AfdelingNaam { get; set; }
    }
}
