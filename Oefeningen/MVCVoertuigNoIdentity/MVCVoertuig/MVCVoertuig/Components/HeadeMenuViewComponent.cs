﻿using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVoertuig.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        VoertuigDbContext _context;
        public HeaderMenuViewComponent(VoertuigDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(
                _context.Voertuigen
                    .Select(x => x.Merk)
                    .Distinct()
                    .OrderBy(x => x));
        }
    }
}
