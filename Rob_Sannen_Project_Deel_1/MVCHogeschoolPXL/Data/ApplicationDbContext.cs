using Microsoft.EntityFrameworkCore;
using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Lector> Lectoren { get; set; }
        public DbSet<VakLector> VakLectoren { get; set; }
        public DbSet<Vak> Vakken { get; set; }
        public DbSet<Handboek> Handboeken { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<AcademieJaar> AcademieJaren { get; set; }
    }
}
