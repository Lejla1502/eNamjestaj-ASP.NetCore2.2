#pragma checksum "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36ca3777571f8ccbda3bf6790c55967bd4187025"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulAdministrator_Views_Logs), @"mvc.1.0.view", @"/Areas/ModulAdministrator/Views/Logs.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulAdministrator/Views/Logs.cshtml", typeof(AspNetCore.Areas_ModulAdministrator_Views_Logs))]
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
#line 1 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\_ViewImports.cshtml"
using eNamjestaj.Web;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\_ViewImports.cshtml"
using eNamjestaj.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36ca3777571f8ccbda3bf6790c55967bd4187025", @"/Areas/ModulAdministrator/Views/Logs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulAdministrator/Views/_ViewImports.cshtml")]
    public class Areas_ModulAdministrator_Views_Logs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.LogIndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
  
    //Layout = null;

#line default
#line hidden
            BeginContext(101, 272, true);
            WriteLiteral(@"
<br />
<br />
<br />
<table class=""table table-bordered"">
    <thead>
        <tr>

            <th>Korisničko ime</th>
            <th>IP adresa</th>
            <th>Akcija poduzeta</th>
            <th>Vrijeme</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 21 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
         foreach (var x in Model.Audits)
        {

#line default
#line hidden
            BeginContext(426, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(465, 10, false);
#line 24 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
               Write(x.Username);

#line default
#line hidden
            EndContext();
            BeginContext(475, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(503, 11, false);
#line 25 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
               Write(x.IPAddress);

#line default
#line hidden
            EndContext();
            BeginContext(514, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(542, 14, false);
#line 26 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
               Write(x.AreaAccessed);

#line default
#line hidden
            EndContext();
            BeginContext(556, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(584, 11, false);
#line 27 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
               Write(x.Timestamp);

#line default
#line hidden
            EndContext();
            BeginContext(595, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 29 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Logs.cshtml"
        }

#line default
#line hidden
            BeginContext(632, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.LogIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
