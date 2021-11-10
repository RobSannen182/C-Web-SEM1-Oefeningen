using MVCHogeschoolPXL.Data;
using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.ViewModels
{
    public class GebruikerInfo
    {
        public GebruikerInfo()
        {

        }

        public GebruikerInfo(ApplicationDbContext context, Gebruiker gebruiker)
        {
            
            GebruikerId = gebruiker.GebruikerId;
            Naam = gebruiker.Naam;
            Voornaam = gebruiker.Voornaam;
            Email = gebruiker.Email;
            if (context.Lectoren.Any(x => x.GebruikerId == gebruiker.GebruikerId))
            {
                Functie = "Lector";
            }
            else if (context.Studenten.Any(x => x.GebruikerId == gebruiker.GebruikerId))
            {
                Functie = "Student";
            }
        }
        
        [DisplayName("Id")]
        public int GebruikerId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Functie { get; set; }
       
    }
}
