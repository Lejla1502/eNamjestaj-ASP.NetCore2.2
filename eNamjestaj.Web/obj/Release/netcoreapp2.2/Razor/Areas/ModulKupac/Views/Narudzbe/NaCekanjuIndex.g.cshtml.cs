#pragma checksum "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3c5f11c51eaba2bc38645a9b0b6a331dc738d83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulKupac_Views_Narudzbe_NaCekanjuIndex), @"mvc.1.0.view", @"/Areas/ModulKupac/Views/Narudzbe/NaCekanjuIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulKupac/Views/Narudzbe/NaCekanjuIndex.cshtml", typeof(AspNetCore.Areas_ModulKupac_Views_Narudzbe_NaCekanjuIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3c5f11c51eaba2bc38645a9b0b6a331dc738d83", @"/Areas/ModulKupac/Views/Narudzbe/NaCekanjuIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulKupac/Views/_ViewImports.cshtml")]
    public class Areas_ModulKupac_Views_Narudzbe_NaCekanjuIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulKupac.ViewModels.NaCekanjuIndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
  
    //Layout = null;

#line default
#line hidden
            BeginContext(97, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(125, 46, true);
            WriteLiteral("    <h1>Narudžbe na čekanju</h1>\r\n    <br />\r\n");
            EndContext();
            BeginContext(173, 496, true);
            WriteLiteral(@"    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class="" table table-bordered"" width=""100%"" cellspacing=""0"">
                <thead>
                    <tr>
                        <th>Datum</th>
                        <th>Ukupan iznos</th>
                        <th>Otkazano</th>
                        <th>Na čekanju</th>

                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 26 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                     foreach (var x in Model.Narudzbe)
                    {

#line default
#line hidden
            BeginContext(748, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(811, 7, false);
#line 29 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                           Write(x.Datum);

#line default
#line hidden
            EndContext();
            BeginContext(818, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(858, 13, false);
#line 30 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                           Write(x.UkupanIznos);

#line default
#line hidden
            EndContext();
            BeginContext(871, 42, true);
            WriteLiteral(" KM</td>\r\n                            <td>");
            EndContext();
            BeginContext(915, 24, false);
#line 31 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                            Write(x.Otkazana ? "Da" : "Ne");

#line default
#line hidden
            EndContext();
            BeginContext(940, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(981, 25, false);
#line 32 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                            Write(x.NaCekanju ? "Da" : "Ne");

#line default
#line hidden
            EndContext();
            BeginContext(1007, 96, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <button ajax-poziv=\"da\"");
            EndContext();
            BeginWriteAttribute("ajax-url", " ajax-url=\"", 1103, "\"", 1167, 2);
            WriteAttributeValue("", 1114, "/ModulKupac/Narudzbe/Detalji?narudzbaId=", 1114, 40, true);
#line 34 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
WriteAttributeValue("", 1154, x.NarudzbaId, 1154, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1168, 81, true);
            WriteLiteral(" ajax-rezultat=\"detailsNaCekanjuDiv\" class=\"btn btn-success\">Detalji</button> |\r\n");
            EndContext();
#line 35 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                                 if (x.NaCekanju)
                                {


#line default
#line hidden
            BeginContext(1337, 86, true);
            WriteLiteral("                                    <button id=\"otkaziNarudzbu\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("par", " par=\"", 1423, "\"", 1442, 1);
#line 38 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
WriteAttributeValue("", 1429, x.NarudzbaId, 1429, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1443, 18, true);
            WriteLiteral(">Otkaži</button>\r\n");
            EndContext();
#line 39 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                                }

#line default
#line hidden
            BeginContext(1496, 66, true);
            WriteLiteral("                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 42 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
                    }

#line default
#line hidden
            BeginContext(1585, 354, true);
            WriteLiteral(@"                </tbody>
            </table>
        </div>
        <br />
        <div style="" padding-left:12px;""><i class=""fas fa-caret-left""></i><a href=""/ModulKupac/Proizvodi/Index"" style="""">Nazad na kupovinu</a></div>

    </div>
            <br />
            <br />
            <div id=""detailsNaCekanjuDiv""></div>
            <br />
");
            EndContext();
            BeginContext(1951, 1939, true);
            WriteLiteral(@"            <script>
                $(""button[ajax-poziv='da']"").click(function (event) {

                    var btn = $(this);

                    var url = btn.attr(""ajax-url"");
                    var r = btn.attr(""ajax-rezultat"");

                    $.get(url,
                        function (rezultat, status) {
                            $(""#"" + r).html(rezultat);

                        });
                });


                $(""#otkaziNarudzbu"").click(function () {
                    //e.preventDefault();
                    var btn = $(this);
                    var p1 = btn.attr(""par"");

                    //var message_alert = $('<p>Da li ste sigurni da želite otkazati narudžbu?</p>').dialog({
                    //    buttons: {
                    //        ""Yes"": function () {
                    //            var url = ""/ModulKupac/Narudzbe/OtkaziNarudzbu?narudzbaId="" + p1;

                    //            $.get(url,
                    //               ");
            WriteLiteral(@" function (rezultat, status) {
                    //                    window.location.reload();
                    //                }); },
                    //        ""No"": function () { alert('you clicked on no'); }
                    //    }
                    //});
                    //})


                    if (confirm('Da li ste sigurni da želite otkazati narudžbu?')) {
                        var url = ""/ModulKupac/Narudzbe/OtkaziNarudzbu?narudzbaId="" + p1;

                        $.get(url,
                            function (rezultat, status) {
                                window.location.reload();
                            });
                    }
                    else {
                        return;
                    }

                    //alert(""Da li ste sigurni da želite otkazati narudžbu?"");
                });

            </script>
");
            EndContext();
#line 112 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(3938, 90, true);
            WriteLiteral("            <br />\r\n            <br />\r\n            <div>Nema narudžbi na čekanju!</div>\r\n");
            EndContext();
#line 118 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Narudzbe\NaCekanjuIndex.cshtml"
            }

#line default
#line hidden
            BeginContext(4043, 4, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulKupac.ViewModels.NaCekanjuIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
