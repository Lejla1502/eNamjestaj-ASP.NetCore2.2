#pragma checksum "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "639a239f92d85c3166f431c65cc80496810f0960"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulAdministrator_Views_Korisnici_IndexZaposlenici), @"mvc.1.0.view", @"/Areas/ModulAdministrator/Views/Korisnici/IndexZaposlenici.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulAdministrator/Views/Korisnici/IndexZaposlenici.cshtml", typeof(AspNetCore.Areas_ModulAdministrator_Views_Korisnici_IndexZaposlenici))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"639a239f92d85c3166f431c65cc80496810f0960", @"/Areas/ModulAdministrator/Views/Korisnici/IndexZaposlenici.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulAdministrator/Views/_ViewImports.cshtml")]
    public class Areas_ModulAdministrator_Views_Korisnici_IndexZaposlenici : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.ZaposleniciIndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(198, 262, true);
            WriteLiteral(@"

<table class="" table table-bordered"">
    <thead>
        <tr>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Korisničko ime</th>
            <th>Uloga</th>
            <th>Akcija</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 17 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
         foreach (var x in Model.Zaposlenici)
        {

#line default
#line hidden
            BeginContext(518, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(557, 5, false);
#line 20 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
               Write(x.Ime);

#line default
#line hidden
            EndContext();
            BeginContext(562, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(590, 9, false);
#line 21 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
               Write(x.Prezime);

#line default
#line hidden
            EndContext();
            BeginContext(599, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(627, 15, false);
#line 22 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
               Write(x.KorisnickoIme);

#line default
#line hidden
            EndContext();
            BeginContext(642, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(670, 7, false);
#line 23 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
               Write(x.Uloga);

#line default
#line hidden
            EndContext();
            BeginContext(677, 107, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <button ajax-poziv=\"da\" ajax-rezultat=\"divUrediZaposlenik\"");
            EndContext();
            BeginWriteAttribute("ajax-url", " ajax-url=\"", 784, "\"", 861, 2);
            WriteAttributeValue("", 795, "/ModulAdministrator/Zaposlenici/Uredi?zaposlenikId=", 795, 51, true);
#line 25 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
WriteAttributeValue("", 846, x.ZaposlenikId, 846, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(862, 116, true);
            WriteLiteral(" class=\"btn btn-primary\">Uredi</button>|\r\n                    <button ajax-poziv=\"da\" ajax-rezultat=\"divZaposlenici\"");
            EndContext();
            BeginWriteAttribute("ajax-url", " ajax-url=\"", 978, "\"", 1044, 2);
            WriteAttributeValue("", 989, "/ModulAdministrator/Zaposlenici/Obrisi?=", 989, 40, true);
#line 26 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
WriteAttributeValue("", 1029, x.ZaposlenikId, 1029, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1045, 83, true);
            WriteLiteral(" class=\"btn btn-danger\">Obriši</button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 29 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulAdministrator\Views\Korisnici\IndexZaposlenici.cshtml"
        }

#line default
#line hidden
            BeginContext(1139, 630, true);
            WriteLiteral(@"    </tbody>
</table>
<br />
<br />
<br />
<div id=""divUrediZaposlenik""></div>
<br />
<br />
<button ajax-poziv=""da"" ajax-rezultat=""divDodajZap"" ajax-url=""/ModulAdministrator/Zaposlenici/Dodaj"" class=""btn btn-success"">Dodaj</button>
<br />
<div id=""divDodajZap""></div>
<br />
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
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulAdministrator.ViewModels.ZaposleniciIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591