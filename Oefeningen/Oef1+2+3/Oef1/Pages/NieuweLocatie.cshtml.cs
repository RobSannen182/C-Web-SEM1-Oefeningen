using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oef1.Pages
{
    public class NieuweLocatieModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var postcode = Request.Form["postcode"];
            var city = Request.Form["city"];
            Oef1.Data.Databank.AddLocatie(postcode, city);
            return RedirectToPage("Locaties");
        }
    }
}
