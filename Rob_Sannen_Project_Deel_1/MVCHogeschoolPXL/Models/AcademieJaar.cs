using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class AcademieJaar
    {
        public int AcademieJaarId { get; set; }
        [DisplayName("Startdatum")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyy}")]
        [Required]
        public DateTime StartDatum { get; set; }

        //public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
