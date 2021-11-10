using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCTagHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTagHelper.Data.DefaultData
{
    public static class SeedData
    {
        public static void MigrateAndPopulate(IApplicationBuilder app)
        {
            TagHelperDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TagHelperDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Landen.Any())
            {
                var be = new Land { LandCode = "BE", LandNaam = "België" };
                var nl = new Land { LandCode = "NL", LandNaam = "Nederland" };
                var d = new Land { LandCode = "D", LandNaam = "Duitsland" };
                context.Landen.AddRange(be, nl);
                var brussel = new Locatie { Stad = "Brussel", Land = be };
                var hasselt = new Locatie { Stad = "Hasselt", Land = be };
                var amsterdam = new Locatie { Stad = "AmsterDam", Land = nl };
                context.Locaties.AddRange(brussel, hasselt, amsterdam);
                var aankoop = new Afdeling { AfdelingNaam = "Aankoop", Locatie = brussel };
                var verkoop = new Afdeling { AfdelingNaam = "Verkoop", Locatie = hasselt };
                var onderzoek = new Afdeling { AfdelingNaam = "Onderzoek", Locatie = amsterdam };
                context.Afdelingen.AddRange(aankoop, verkoop, onderzoek);
                var med1 = new Medewerker { Afdeling = aankoop, Voornaam = "Rob", Naam = "Sannen", Email = "rs@rs.be" };
                var med2 = new Medewerker { Afdeling = verkoop, Voornaam = "Bob", Naam = "Peeters", Email = "bp@bp.be" };
                context.Medewerkers.AddRange(med1, med2);
                context.SaveChanges();                    
            }
        }
    }
}
