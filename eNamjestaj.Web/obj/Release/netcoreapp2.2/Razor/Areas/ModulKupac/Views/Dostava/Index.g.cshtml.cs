#pragma checksum "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16dc5ad49dfb9d3d56007ac3aa25e4e9b8566829"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulKupac_Views_Dostava_Index), @"mvc.1.0.view", @"/Areas/ModulKupac/Views/Dostava/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulKupac/Views/Dostava/Index.cshtml", typeof(AspNetCore.Areas_ModulKupac_Views_Dostava_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16dc5ad49dfb9d3d56007ac3aa25e4e9b8566829", @"/Areas/ModulKupac/Views/Dostava/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulKupac/Views/_ViewImports.cshtml")]
    public class Areas_ModulKupac_Views_Dostava_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulKupac.ViewModels.DostavaIndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ajax-poziv", new global::Microsoft.AspNetCore.Html.HtmlString("da"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ajax-url", new global::Microsoft.AspNetCore.Html.HtmlString("/ModulKupac/Narudzbe/Zakljuci/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ajax-area", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(107, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(109, 1070, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16dc5ad49dfb9d3d56007ac3aa25e4e9b85668294961", async() => {
                BeginContext(186, 127, true);
                WriteLiteral("\r\n\r\n    <br />\r\n    <br />\r\n    <h1>Opcije dostave</h1>\r\n    <br />\r\n    <input id=\"narudzbaID\" type=\"hidden\" name=\"NarudzbaID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 313, "\"", 338, 1);
#line 12 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
WriteAttributeValue("", 321, Model.NarudzbaID, 321, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(339, 3, true);
                WriteLiteral(" />");
                EndContext();
                BeginContext(403, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
#line 14 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
     foreach (var x in Model.Dostave)
    {


#line default
#line hidden
                BeginContext(455, 52, true);
                WriteLiteral("    <div>\r\n        <input id=\"idRadio\" type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 507, "\"", 520, 1);
#line 18 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
WriteAttributeValue("", 515, x.Id, 515, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(521, 60, true);
                WriteLiteral(" />\r\n        <input id=\"radioId\" type=\"radio\" name=\"dostava\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 581, "\"", 594, 1);
#line 19 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
WriteAttributeValue("", 589, x.Id, 589, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("cijena", " cijena=\"", 595, "\"", 613, 1);
#line 19 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
WriteAttributeValue("", 604, x.Cijena, 604, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(614, 4, true);
                WriteLiteral(" /> ");
                EndContext();
                BeginContext(619, 5, false);
#line 19 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
                                                                                       Write(x.Tip);

#line default
#line hidden
                EndContext();
                BeginContext(624, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(634, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16dc5ad49dfb9d3d56007ac3aa25e4e9b85668298069", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 20 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => x.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(674, 29, true);
                WriteLiteral("<br />\r\n        <p id=\"price\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 703, "\"", 720, 1);
#line 21 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
WriteAttributeValue("", 711, x.Cijena, 711, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(721, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(723, 8, false);
#line 21 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
                                   Write(x.Cijena);

#line default
#line hidden
                EndContext();
                BeginContext(731, 17, true);
                WriteLiteral("</p>\r\n        <p>");
                EndContext();
                BeginContext(749, 6, false);
#line 22 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
      Write(x.Opis);

#line default
#line hidden
                EndContext();
                BeginContext(755, 19, true);
                WriteLiteral(" </p>\r\n    </div>\r\n");
                EndContext();
#line 24 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"

    }

#line default
#line hidden
                BeginContext(783, 26, true);
                WriteLiteral("\r\n    <br />\r\n    <br />\r\n");
                EndContext();
                BeginContext(986, 35, true);
                WriteLiteral("    UKUPNO:\r\n    <div id=\"totalDiv\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1021, "\"", 1041, 1);
#line 31 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
WriteAttributeValue("", 1029, Model.Total, 1029, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1042, 2, true);
                WriteLiteral("> ");
                EndContext();
                BeginContext(1045, 11, false);
#line 31 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Dostava\Index.cshtml"
                                        Write(Model.Total);

#line default
#line hidden
                EndContext();
                BeginContext(1056, 116, true);
                WriteLiteral(" KM</div>\r\n    <br />\r\n    <input type=\"submit\" class=\"btn btn-primary\" value=\"Zaključi narudžbu\" />\r\n    <br />\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1179, 1883, true);
            WriteLiteral(@"

<script>
    $(""input:radio[name=dostava]"").on('change', function () {
        var valtotal = $(""#totalDiv"").attr('value');
        var totalString = valtotal.toString();

        var valDostava = $('input[name=dostava]:checked').attr('cijena'); //$(""#radioId"").attr('cijena');
        var cijenaDouble = parseFloat(valDostava);

        var a = parseFloat($('#totalDiv').attr('value').toString());
        var b = parseFloat($('input[name=dostava]:checked').attr('cijena')).toFixed(2);

        var iNum = parseFloat(a) + parseFloat(b);
        var numFloat = parseFloat(iNum).toFixed(2);
        var stringNew = numFloat.toString();



        if ($('input[name=dostava]:checked').val() > 0) {

            {
                $(""#totalDiv"").text(stringNew + "" KM"");
            }

        }
    });
    $(document).ready(function () {
        $(""form[ajax-poziv='da']"").submit(function (event) {
            $(this).attr(""ajax-poziv"", ""dodan"");
            event.preventDefault();
         ");
            WriteLiteral(@"   var urlZaPoziv1 = $(this).attr(""ajax-url"");

            var form = $(this);
            var val = $('input[name=dostava]:checked').val();

            var narudzbaID = $(""#narudzbaID"").attr('value');

            var total = $(""#totalDiv"").attr('value');

            var formData = form.serialize();

            if (val > 0) {
                $.ajax({
                    type: ""POST"",
                    url: urlZaPoziv1 + ""?narudzbaID="" + narudzbaID + ""&dostava="" + val + ""&total="" + total,
                    data: form.serialize(),
                    success: function (result) {
                        $('form').html(result);
                    }
                });
            }
            else {
                alert(""Morate odabrati način dostave"");
            }

        });
    });



</script>




");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulKupac.ViewModels.DostavaIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591