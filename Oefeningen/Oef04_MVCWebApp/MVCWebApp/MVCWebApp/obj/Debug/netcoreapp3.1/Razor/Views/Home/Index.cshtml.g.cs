#pragma checksum "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8dde3c138745352c598dd4fbaf53d57a2bfbbc79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\_ViewImports.cshtml"
using MVCWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\_ViewImports.cshtml"
using MVCWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
using MVCWebApp.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dde3c138745352c598dd4fbaf53d57a2bfbbc79", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed8858f5cba4f480c7a9955c1fab36ca8554b3eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClientLocationModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Databank is gestart in startup.cs</h1>\r\n    <h4># client records: ");
#nullable restore
#line 10 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
                     Write(Databank.Clients.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <h4># location records: ");
#nullable restore
#line 11 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
                       Write(Databank.Locations.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n</div>\r\n<div>\r\n    <table class=\"table table-bordered\">\r\n");
#nullable restore
#line 15 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 18 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
               Write(item.KlantName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 19 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
               Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 21 "C:\C#Web\Oefeningen\Oef04_MVCWebApp\MVCWebApp\MVCWebApp\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClientLocationModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591