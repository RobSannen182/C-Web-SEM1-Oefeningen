using Microsoft.AspNetCore.Mvc;
using MVCPXLParty2021.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Components
{
    public class LocationFilterMenuViewComponent : ViewComponent
    {
        PartyDbContext _context;
        
        public LocationFilterMenuViewComponent(PartyDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedLocatie = RouteData?.Values["Locatie"];
            return View(
                _context.Locations
                    .Select(x => x.City)
                    .Distinct()
                    .OrderBy(x => x));
        }
    }
    
}
