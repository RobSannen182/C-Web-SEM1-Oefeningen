using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCPXLParty2021.Models;
using MVCPXLParty2021.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    //[HtmlTargetElement(Attributes ="gast")]
    public class GuestPartyHistoryTagHelper : TagHelper
    {
        public GuestPartyHistory GuestPartyHistoryViewModel { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string hoofding = $@"<h1 class='text-center'>{GuestPartyHistoryViewModel.GuestName}</h1>";
            hoofding += $@"<hr />";
            output.Content.AppendHtml(hoofding);

            if (GuestPartyHistoryViewModel.PartyHistory.Count() < 1)
            {
                string content = $@"<h2>Partyverleden</h2>";
                content += $@"<h3 class='text-center'>{GuestPartyHistoryViewModel.GuestName} heeft nog geen party bijgewoond!</h3>";
                content += $@"<hr />";
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "mt-5");
                output.Content.AppendHtml(content);
            }
            else
            {
                string content = $@"<h2>Partyverleden</h2>";
                content += $@"<table class='table'>";
                content += $@"<thead class='thead-light'>";
                content += $@"<tr>";
                content += $@"<th>Party datum</th>";
                content += $@"<th>Party naam</th>";
                content += $@"<th>Locatie</th>";
                content += $@"</tr>";
                content += $@"</thead>";
                content += $@"<tbody>";
                foreach (var party in GuestPartyHistoryViewModel.PartyHistory)
                {
                    content += $@"<tr>";
                    content += $@"<td>{party.Party.PartyDate}</td>";
                    content += $@"<td>{party.Party.PartyName}</td>";
                    content += $@"<td>{party.Party.Location.City}</td>";
                    content += $@"</tr>";
                }
                content += $@"</tbody>";
                content += $@"</table>";
                content += $@"<hr />";
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "container");
                output.Content.AppendHtml(content);
            }
            if (GuestPartyHistoryViewModel.PartyFuture.Count() < 1)
            {
                string content = $@"<h2>Partytoekomst</h2>";
                content += $@"<h3 class='text-center'>{GuestPartyHistoryViewModel.GuestName} heeft geen parties geboekt!</h3>";
                content += $@"<hr />";
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "mt-5");
                output.Content.AppendHtml(content);
            }
            else
            {
                string content = $@"<h2>Partytoekomst</h2>";
                content += $@"<table class='table'>";
                content += $@"<thead class='thead-light'>";
                content += $@"<tr>";
                content += $@"<th>Party datum</th>";
                content += $@"<th>Party naam</th>";
                content += $@"<th>Locatie</th>";
                content += $@"</tr>";
                content += $@"</thead>";
                content += $@"<tbody>";
                foreach (var party in GuestPartyHistoryViewModel.PartyFuture)
                {
                    content += $@"<tr>";
                    content += $@"<td>{party.Party.PartyDate}</td>";
                    content += $@"<td>{party.Party.PartyName}</td>";
                    content += $@"<td>{party.Party.Location.City}</td>";
                    content += $@"</tr>";
                }
                content += $@"</tbody>";
                content += $@"</table>";
                content += $@"<hr />";
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "container");
                output.Content.AppendHtml(content);
            }
        }
    }
}
