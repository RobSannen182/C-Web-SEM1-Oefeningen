using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOefening07.Models
{
    public class MedewerkerAfdeling
    {
        public int Id { get; set; }

        [Required]
        public int MedewerkerId { get; set; }

        [Required]
        public int AfdelingId { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        public DateTime EindDatum { get; set; }
    }
}
