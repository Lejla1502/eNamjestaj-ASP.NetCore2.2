#pragma checksum "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6065d81e2e70229b7ebbd5e9c35749e42e01ae67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulKupac_Views_Narudzbe_Index), @"mvc.1.0.view", @"/Areas/ModulKupac/Views/Narudzbe/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulKupac/Views/Narudzbe/Index.cshtml", typeof(AspNetCore.Areas_ModulKupac_Views_Narudzbe_Index))]
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
#line 1 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\_ViewImports.cshtml"
using eNamjestaj.Web;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\_ViewImports.cshtml"
using eNamjestaj.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6065d81e2e70229b7ebbd5e9c35749e42e01ae67", @"/Areas/ModulKupac/Views/Narudzbe/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulKupac/Views/_ViewImports.cshtml")]
    public class Areas_ModulKupac_Views_Narudzbe_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulKupac.ViewModels.NarudzbeIndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(108, 22, true);
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n\r\n");
            EndContext();
#line 10 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(154, 37, true);
            WriteLiteral("<h1>Historija narudzbi</h1>\r\n<br />\r\n");
            EndContext();
            BeginContext(193, 293, true);
            WriteLiteral(@"<table class="" table table-bordered"">
    <thead>
        <tr>
            <th>Datum</th>
            <th>Ukupan iznos</th>
            <th>Otkazano</th>
            <th>Zakljucena</th>
            <th>Status</th>
            <th>Akcija</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 27 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
         foreach (var x in Model.Narudzbe)
            {

#line default
#line hidden
            BeginContext(545, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(576, 7, false);
#line 30 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
           Write(x.Datum);

#line default
#line hidden
            EndContext();
            BeginContext(583, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(607, 13, false);
#line 31 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
           Write(x.UkupanIznos);

#line default
#line hidden
            EndContext();
            BeginContext(620, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(645, 24, false);
#line 32 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
            Write(x.Otkazana ? "Da" : "Ne");

#line default
#line hidden
            EndContext();
            BeginContext(670, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(695, 14, false);
#line 33 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
            Write(x.Kompletirana);

#line default
#line hidden
            EndContext();
            BeginContext(710, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 34 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
             if (x.Otkazana)
                    {

#line default
#line hidden
            BeginContext(770, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(788, 27, false);
#line 36 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
            Write(x.Status ? "" : "Neaktivna");

#line default
#line hidden
            EndContext();
            BeginContext(816, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 37 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(895, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(913, 45, false);
#line 40 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
            Write(x.Status ? "U putu" : "Stigla na destinaciju");

#line default
#line hidden
            EndContext();
            BeginContext(959, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 41 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(989, 59, true);
            WriteLiteral("\r\n            <td>\r\n                <button ajax-poziv=\"da\"");
            EndContext();
            BeginWriteAttribute("ajax-url", " ajax-url=\"", 1048, "\"", 1112, 2);
            WriteAttributeValue("", 1059, "/ModulKupac/Narudzbe/Detalji?narudzbaId=", 1059, 40, true);
#line 44 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
WriteAttributeValue("", 1099, x.NarudzbaId, 1099, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1113, 104, true);
            WriteLiteral(" ajax-rezultat=\"detailsDiv\" class=\"btn btn-success\">Detalji</button>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 47 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1232, 503, true);
            WriteLiteral(@"    </tbody>
</table>
<br />
<br />
<div id=""detailsDiv""></div>
<br />
<a href=""/ModulKupac/Proizvodi/Index"" style=""text-align:left"">Back to shopping</a>
<br />
<script>
    $(""button[ajax-poziv='da']"").click(function (event) {

        var btn = $(this);

        var url = btn.attr(""ajax-url"");
        var r = btn.attr(""ajax-rezultat"");

        $.get(url,
            function (rezultat, status) {
                $(""#"" + r).html(rezultat);

            });
    });
</script>
");
            EndContext();
#line 71 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1747, 68, true);
            WriteLiteral("<br />\r\n<br />\r\n<div>Niste jos izvrsili niti jednu narudzbu!</div>\r\n");
            EndContext();
#line 77 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1818, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulKupac.ViewModels.NarudzbeIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591