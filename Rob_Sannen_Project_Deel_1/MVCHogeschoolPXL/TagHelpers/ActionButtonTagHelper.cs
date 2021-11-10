using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.TagHelpers
{
    [HtmlTargetElement("a", Attributes="color")]
    public class ActionButtonTagHelper : TagHelper
    {
        public string Color { get; set; } 

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{Color} mx-1");
        }
    }
}
