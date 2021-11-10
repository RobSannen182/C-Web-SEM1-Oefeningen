using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFifa2021.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public Team Team { get; set; } // Dit zorgt automatisch voor de koppeling tussen de Team tabel
                                       // en kolom teamId hierboven(FK)
        
        public Player Player { get; set; }
    }
}
