#pragma checksum "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dba55d51377596346edd6b5b20f2969a665b5fe9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ModulKupac_Views_Profil_Index), @"mvc.1.0.view", @"/Areas/ModulKupac/Views/Profil/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/ModulKupac/Views/Profil/Index.cshtml", typeof(AspNetCore.Areas_ModulKupac_Views_Profil_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dba55d51377596346edd6b5b20f2969a665b5fe9", @"/Areas/ModulKupac/Views/Profil/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75d1de2be480932e6593590e71e3561d65160e1", @"/Areas/ModulKupac/Views/_ViewImports.cshtml")]
    public class Areas_ModulKupac_Views_Profil_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eNamjestaj.Web.Areas.ModulKupac.ViewModels.ProfilIndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(66, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(68, 148, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dba55d51377596346edd6b5b20f2969a665b5fe94272", async() => {
                BeginContext(74, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(80, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dba55d51377596346edd6b5b20f2969a665b5fe94655", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(127, 82, true);
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/lib/bootstrap/dist/css/bootstrap.css\" />\r\n\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(216, 329, true);
            WriteLiteral(@"
<br />
<div class=""container-fluid userProfile"">

    <div class=""col-md-8"">
        <div class=""glyphicon glyphicon-user"" style=""font-size: 5em !important; display:block !important; padding-left:45px !important;""></div>
        <div id=""imePrezimeLabel"" style=""display:block; padding-bottom:20px; padding-left:20px;""><h1>");
            EndContext();
            BeginContext(546, 9, false);
#line 14 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml"
                                                                                                Write(Model.Ime);

#line default
#line hidden
            EndContext();
            BeginContext(555, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(558, 13, false);
#line 14 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml"
                                                                                                            Write(Model.Prezime);

#line default
#line hidden
            EndContext();
            BeginContext(571, 144, true);
            WriteLiteral("</h1></div>\r\n        <div id=\"userName\" style=\"display:block; padding-bottom:20px; padding-left:20px; font-size: 1.6em;\"><b>Korisničko ime:</b> ");
            EndContext();
            BeginContext(716, 19, false);
#line 15 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml"
                                                                                                                              Write(Model.KorisnickoIme);

#line default
#line hidden
            EndContext();
            BeginContext(735, 132, true);
            WriteLiteral("</div>\r\n        <div id=\"emailLabel\" style=\"display:block; padding-bottom:20px; padding-left:20px; font-size: 1.6em;\"><b>Email:</b> ");
            EndContext();
            BeginContext(868, 11, false);
#line 16 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml"
                                                                                                                       Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(879, 134, true);
            WriteLiteral("</div>\r\n        <div id=\"adresaLabel\" style=\"display:block; padding-bottom:20px; padding-left:20px; font-size: 1.6em;\"><b>Adresa:</b> ");
            EndContext();
            BeginContext(1014, 12, false);
#line 17 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml"
                                                                                                                         Write(Model.Adresa);

#line default
#line hidden
            EndContext();
            BeginContext(1026, 136, true);
            WriteLiteral("</div>\r\n        <div id=\"opstinaLabel\" style=\"display:block; padding-bottom:20px; padding-left:20px; font-size: 1.6em;\"><b>Opstina:</b> ");
            EndContext();
            BeginContext(1163, 13, false);
#line 18 "C:\Users\User\source\repos\eNamjestaj\eNamjestaj.Web\Areas\ModulKupac\Views\Profil\Index.cshtml"
                                                                                                                           Write(Model.Opstina);

#line default
#line hidden
            EndContext();
            BeginContext(1176, 260, true);
            WriteLiteral(@"</div>
    </div>
    
</div>



<div class=""row userProfile"">
    <div class=""col-md-8"" style=""padding-left:60px !important;"">
        
        <a class=""btn btn-primary"" href=""/ModulKupac/Profil/Uredi"">Uredi profil</a>

    </div>
</div>



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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eNamjestaj.Web.Areas.ModulKupac.ViewModels.ProfilIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
