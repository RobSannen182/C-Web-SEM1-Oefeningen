using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oef1.Pages
{
    public class NieuweKlantModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var naam = Request.Form["naam"];
            var locId = int.Parse(Request.Form["locatieSelect"]);
            Oef1.Data.Databank.AddKlant(naam, locId);
            return RedirectToPage("Klant");
        }
    }
}
