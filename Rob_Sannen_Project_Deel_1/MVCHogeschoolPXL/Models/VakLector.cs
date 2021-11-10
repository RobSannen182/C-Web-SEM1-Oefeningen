using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class VakLector
    {
        [DisplayName("Vaklector id")]
        public int VaklectorId { get; set; }

        [DisplayName("Vaklector id")]
        [Required]
        public int VakId { get; set; }

        [Required]
        [DisplayName("Lector")]
        public int LectorId { get; set; }
        //public Vak Vak { get; set; }
        //public Lector Lector { get; set; }
        //public ICollection<Inschrijving> Inschrijvingen { get; set; }

    }
}
