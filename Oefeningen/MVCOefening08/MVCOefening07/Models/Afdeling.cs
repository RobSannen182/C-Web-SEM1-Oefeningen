using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOefening07.Models
{
    public class Afdeling
    {
        public int AfdelingId { get; set; }

        [Required]
        public string AfdelingNaam { get; set; }
    }
}
