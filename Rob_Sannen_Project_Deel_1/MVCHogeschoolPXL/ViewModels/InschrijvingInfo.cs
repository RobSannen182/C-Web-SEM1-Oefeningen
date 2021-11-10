using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.ViewModels
{
    public class InschrijvingInfo
    {
        public InschrijvingInfo()
        {

        }
        public InschrijvingInfo(Inschrijving inschrijving)
        {
            StudentFullName = $"{inschrijving.Student.Gebruiker.Voornaam} {inschrijving.Student.Gebruiker.Naam}";
            VakNaam = inschrijving.VakLector.Vak.VakNaam;
            LectorFullName = $"{inschrijving.VakLector.Lector.Gebruiker.Voornaam} {inschrijving.VakLector.Lector.Gebruiker.Naam}";
            AcademieJaar = inschrijving.AcademieJaar.StartDatum;
            InschrijvingId = inschrijving.InschrijvingId;
            VakLectorId = inschrijving.VakLectorId;
        }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int LectorId { get; set; }
        [Required]
        public int VakId { get; set; }
        public int InschrijvingId { get; set; }
        [DisplayName("Naam student")]
        public string StudentFullName { get; set; }
        public int AcademieJaarId { get; set; }
        public DateTime AcademieJaar { get; set; }
        [DisplayName("Vaknaam")]
        public string VakNaam { get; set; }
        [DisplayName("Naam lector")]
        public string LectorFullName { get; set; }
        public int VakLectorId { get; set; }
    }
}
