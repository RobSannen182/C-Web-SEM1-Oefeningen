using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class Gebruiker
    {
        [DisplayName("Gebruiker id")]
        public int GebruikerId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Onjuist e-mailadres!")]
        public string Email { get; set; }
    }
}
