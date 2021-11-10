using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVoertuig.Models
{
    public class Voertuig
    {
        public int VoertuigId { get; set; }

        [Required]
        public string Merk { get; set; }

        [Required]
        public string MerkType { get; set; }

        [Required]
        public int Bouwjaar { get; set; }

        [Required]
        public int Km { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal VerkoopPrijs { get; set; }

        public bool AanwezigInShowroom { get; set; }

    }
}
