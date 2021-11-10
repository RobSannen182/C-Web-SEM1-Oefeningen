using Microsoft.AspNetCore.Mvc;
using MVCHogeschoolPXL.Data;
using MVCHogeschoolPXL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Components
{
    public class GebruikerFilterViewComponent : ViewComponent
    {
        private GebruikersRepo _repo;

        public GebruikerFilterViewComponent(ApplicationDbContext context)
        {
            _repo = new GebruikersRepo(context);
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["functie"];
            List<GebruikerInfo> gebruikersList = _repo.GetGebruikersInfoList();
            List<string> functieList = gebruikersList
                .Select(x => x.Functie)
                .Distinct()
                .OrderBy(x => x).ToList();
            return View(functieList);
        }
    }
}
