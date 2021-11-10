using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.ViewModels
{
    public class StudentNaamId
    {
        public StudentNaamId(Student s)
        {
            StudentId = s.StudentId;
            Naam = s.Gebruiker.Naam;
            VoorNaam = s.Gebruiker.Voornaam;
        }

        public int StudentId { get; set; }
        public string Naam { get; set; }
        public string VoorNaam { get; set; }
        public string FullName { get => $"{VoorNaam} {Naam}"; }
    }

    
}
