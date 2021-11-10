using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFifa2021.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; } // TeamId kan hierdoor meerdere keren
                                                                 // voorkomen in TeamPlayer tabel
    }
}
