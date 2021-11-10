using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCSportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSportStore.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    // [HtmlTargetElement("tag-name")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var current = PageModel.CurrentPage;
            var total = PageModel.Totalpages;
            output.TagName = "div";
            output.PreContent.SetHtmlContent(@"<ul class='pagination'>");
            for (int i = 1; i <= total; i++)
            {
                output.Content.AppendHtml(GetLink(i, current, total));
            }
            output.PostContent.SetHtmlContent("</ul>");
        }
        private string GetLink(int linkId, int currentPage, int totalPages)
        {
            string link = $@"<li class=""{(linkId == currentPage ? "active" : "")}"">";
            link += $"<a class='btn border mt-3' href=/Home/Index/{linkId} ";
            link += $"title = Click to go to page {linkId}>{linkId}</a></li>";
            return link;
        }
    }
}
