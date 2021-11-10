﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTagHelper.Models
{
    public class Locatie
    {
        public int LocatieId { get; set; }
        public string Stad { get; set; }
        public int LandId { get; set; }
        public ICollection<Afdeling> Afdelingen { get; set; }
        public Land Land { get; set; }
    }
}
