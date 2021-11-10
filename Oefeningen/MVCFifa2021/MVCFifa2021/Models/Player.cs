using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFifa2021.Models
{
    public class Player
    {
        public int PlayerId { get; set; } // Id in de naam zorgt automatisch dat dit PK wordt in db (Entity framework)
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ImageLink { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; } // PlayerId kan hierdoor meerdere keren
                                                                 // voorkomen in TeamPlayer tabel
    }
}
