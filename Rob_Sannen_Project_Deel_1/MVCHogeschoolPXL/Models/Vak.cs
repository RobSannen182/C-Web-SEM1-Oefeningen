using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class Vak
    {
        [DisplayName("Vak id")]
        public int VakId { get; set; }
        [DisplayName("Vaknaam")]
        [Required]
        public string VakNaam { get; set; }
        [Required]
        public int Studiepunten { get; set; }
        [DisplayName("Handboek")]
        [Required]
        public int HandboekId { get; set; }

        //public Handboek Handboek { get; set; }
        //public ICollection<VakLector> VakLectoren { get; set; }
    }
}
