using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOefening07.Models
{
    public class Medewerker
    {
        public int MedewerkerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Naam { get; set; }
        [Required]
        [StringLength(50)]
        public string Voornaam { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
