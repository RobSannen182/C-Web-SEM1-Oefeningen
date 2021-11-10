using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVoertuig.Data
{
    public class VoertuigDbContext : IdentityDbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options)
        {
        }
        public DbSet<Voertuig> Voertuigen { get; set; }
    }
}
