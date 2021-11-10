using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Gebruikers.Any())
            {
                Gebruiker g = new Gebruiker { Naam = "Sannen", Voornaam = "Rob", Email = "rob@rob.be" };
                Gebruiker gg = new Gebruiker { Naam = "Palmaers", Voornaam = "Kristof", Email = "kristof.palmaers@pxl.be" };
                context.Gebruikers.AddRange(g, gg);
                context.SaveChanges();
                var gebruiker1Id = context.Gebruikers.Where(x => x.Voornaam == "Rob").Select(x => x.GebruikerId).SingleOrDefault();
                Student s = new Student { GebruikerId = gebruiker1Id };
                context.Studenten.AddRange(s);
                context.SaveChanges();
                var gebruiker2 = context.Gebruikers.Where(x => x.Voornaam == "Kristof").FirstOrDefault();
                Lector l = new Lector { GebruikerId = gebruiker2.GebruikerId };
                context.Lectoren.AddRange(l);
                context.SaveChanges();
                Handboek h = new Handboek { Titel = "C# Web 1", Kostprijs = 49.99m, UitgifteDatum = Convert.ToDateTime("10/10/2020"), Afbeelding = "C# Web 1" };
                context.Handboeken.AddRange(h);
                context.SaveChanges();
                var handboek = context.Handboeken.Where(x => x.Titel == "C# Web 1").FirstOrDefault();
                Vak v = new Vak { VakNaam = "C# Web 1", Studiepunten = 15, HandboekId = handboek.HandboekId };
                context.Vakken.AddRange(v);
                context.SaveChanges();
                var vak = context.Vakken.Where(x => x.VakNaam == "C# Web 1").FirstOrDefault();
                var lector = context.Lectoren.Where(x => x.GebruikerId == gebruiker2.GebruikerId).FirstOrDefault();
                VakLector vl = new VakLector { VakId = vak.VakId, LectorId = lector.LectorId };
                context.VakLectoren.AddRange(vl);
                context.SaveChanges();
                AcademieJaar a = new AcademieJaar { StartDatum = Convert.ToDateTime("09/20/2021") };
                context.AcademieJaren.AddRange(a);
                context.SaveChanges();
                var student = context.Studenten.Where(x => x.Gebruiker.Voornaam == "Rob").FirstOrDefault();
                Inschrijving i = new Inschrijving { StudentId = student.StudentId, VakLectorId = 1, AcademieJaarId = 1 };
                context.Inschrijvingen.AddRange(i);
                context.SaveChanges();

            }
        }
    }
}
