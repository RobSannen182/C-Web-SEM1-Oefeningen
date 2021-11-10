using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oef1.Pages
{
    public class LocatieDetailsModel : PageModel
    {
        public int LocationId { get; set; }
        public void OnGet(int id)
        {
            LocationId = id;
        }
    }
}
