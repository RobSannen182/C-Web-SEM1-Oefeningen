using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCVoertuig.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCVoertuig.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("car-info")]
    public class CarInfoTagHelper : TagHelper
    {
        VoertuigDbContext _context;
        [HtmlAttributeName("merk")]
        public string Merk { get; set; }
        public CarInfoTagHelper(VoertuigDbContext context)
        {
            _context = context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<button type='button' class='btn btn-primary'>");
            html.Append("Aantal voertuigen ");
            html.Append("<span class='badge badge-light'>");
            html.Append($"{GetCarCount()}");
            html.Append("</span>");
            html.Append("</button>");
            output.Content.SetHtmlContent(html.ToString());
        }
        private int GetCarCount()
        {
            int count = 0;
            if (string.IsNullOrEmpty(Merk))
            {
                count = _context.Voertuigen.Count();
            }
            else
            {
                count = _context.Voertuigen.Where(x => x.Merk == Merk).Count();
            }
            return count;
        }
    }
}
