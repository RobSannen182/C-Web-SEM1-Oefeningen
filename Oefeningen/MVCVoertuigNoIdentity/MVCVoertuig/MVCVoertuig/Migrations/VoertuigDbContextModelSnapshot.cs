﻿// <auto-generated />
using MVCVoertuig.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCVoertuig.Migrations
{
    [DbContext(typeof(VoertuigDbContext))]
    partial class VoertuigDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCVoertuig.Models.Voertuig", b =>
                {
                    b.Property<int>("VoertuigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AanwezigInShowroom")
                        .HasColumnType("bit");

                    b.Property<int>("Bouwjaar")
                        .HasColumnType("int");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<string>("Merk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VerkoopPrijs")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("VoertuigId");

                    b.ToTable("Voertuigen");
                });
#pragma warning restore 612, 618
        }
    }
}
