using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class Inschrijving
    {
        [DisplayName("Inschrijving id")]
        public int InschrijvingId { get; set; }
        public int StudentId { get; set; }
        public int VakLectorId { get; set; }
        public int AcademieJaarId { get; set; }

        //public Student Student { get; set; }
        //public VakLector VakLector { get; set; }
        //public AcademieJaar AcademieJaar { get; set; }
    }
}
