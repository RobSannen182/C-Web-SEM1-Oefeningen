using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class Lector
    {
        public int LectorId { get; set; }
        [Required]
        public int GebruikerId { get; set; }

        //public Gebruiker Gebruiker { get; set; }
        //public ICollection<VakLector> VakLectoren { get; set; }
    }
}
