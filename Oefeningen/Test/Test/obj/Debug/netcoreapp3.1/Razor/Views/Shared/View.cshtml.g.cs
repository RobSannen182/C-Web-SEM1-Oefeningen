#pragma checksum "C:\C#Web\Oefeningen\Test\Test\Views\Shared\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6054437e7689a55ff571e8ca420c30ac4267b466"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_View), @"mvc.1.0.view", @"/Views/Shared/View.cshtml")]
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
#line 1 "C:\C#Web\Oefeningen\Test\Test\Views\_ViewImports.cshtml"
using Test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\C#Web\Oefeningen\Test\Test\Views\_ViewImports.cshtml"
using Test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6054437e7689a55ff571e8ca420c30ac4267b466", @"/Views/Shared/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8de0cd09606eebd3be5ea608a7d900d512bd7bd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test.Models.Auto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div>\r\n    <table>\r\n        <tr>\r\n            <th>Id</th>\r\n            <th>Merk</th>\r\n            <th>Km stand</th>\r\n            <th>Leeftijd</th>\r\n        </tr>\r\n        <tr>\r\n            <td>");
#nullable restore
#line 13 "C:\C#Web\Oefeningen\Test\Test\Views\Shared\View.cshtml"
           Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 14 "C:\C#Web\Oefeningen\Test\Test\Views\Shared\View.cshtml"
           Write(Model.Merk);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 15 "C:\C#Web\Oefeningen\Test\Test\Views\Shared\View.cshtml"
           Write(Model.KmStand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 16 "C:\C#Web\Oefeningen\Test\Test\Views\Shared\View.cshtml"
           Write(Model.Leeftijd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Test.Models.Auto> Html { get; private set; }
    }
}
#pragma warning restore 1591