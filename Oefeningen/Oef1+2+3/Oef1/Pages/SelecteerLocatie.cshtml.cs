using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oef1.Pages
{
    public class SelecteerLocatieModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var locId = Request.Form["LocationSelect"];
            int id = int.Parse(locId);
            return RedirectToPage("LocatieDetails", new { id });
        }
    }
}
