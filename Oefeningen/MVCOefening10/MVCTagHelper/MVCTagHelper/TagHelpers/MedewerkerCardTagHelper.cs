﻿using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCTagHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTagHelper.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes ="medewerker-card-view-model")]
    public class MedewerkerCardTagHelper : TagHelper
    {
        public MedewerkerCard MedewerkerCardViewModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='card'>";
            content += $@"<h4 class='card-title'>{MedewerkerCardViewModel.MedewerkerNaam}</h4>";
            content += $@"<p class='card-position'>{MedewerkerCardViewModel.MedewerkerId}</p>";
            content += $@"<p class='card-description'>De medewerker {MedewerkerCardViewModel.MedewerkerNaam} werkt in afdeling {MedewerkerCardViewModel.AfdelingNaam}.</p>";
            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
