using Microsoft.AspNetCore.Mvc;
using MVCHogeschoolPXL.Data;
using MVCHogeschoolPXL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Components
{
    public class CursusFilterViewComponent : ViewComponent
    {
        private ApplicationDbContext _context;

        public CursusFilterViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["vakNaam"];
            var vakkenList = _context.Vakken.ToList();
            return View(vakkenList);
        }
    }
}
