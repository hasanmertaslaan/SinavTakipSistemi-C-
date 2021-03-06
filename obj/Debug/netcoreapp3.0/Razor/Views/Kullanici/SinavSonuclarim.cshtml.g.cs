#pragma checksum "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e0fe55b5e3143710ef6792fe7c0672733a05496"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kullanici_SinavSonuclarim), @"mvc.1.0.view", @"/Views/Kullanici/SinavSonuclarim.cshtml")]
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
#line 1 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\_ViewImports.cshtml"
using SinavTakipSistemi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\_ViewImports.cshtml"
using SinavTakipSistemi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e0fe55b5e3143710ef6792fe7c0672733a05496", @"/Views/Kullanici/SinavSonuclarim.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7c7dc880b7d044ee79c1c65c9edd9d1fc08fe3a", @"/Views/_ViewImports.cshtml")]
    public class Views_Kullanici_SinavSonuclarim : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
  
    ViewData["Title"] = "Sınav Sonuçlarım";
    List<SinavSonucu> sinavsonuclari = ViewBag.sinavsonuclari;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
 if (TempData["error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\" role=\"alert\">\r\n        ");
#nullable restore
#line 10 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
   Write(TempData["error"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Sınav Sonuçları</h1>\r\n</div>\r\n<div class=\"container\">\r\n");
#nullable restore
#line 17 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
     if (sinavsonuclari.Count != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <th scope=""col"">Sınav</th>
                    <th scope=""col"">Soru Sayısı</th>
                    <th scope=""col"">Doğru Cevap Sayısı</th>
                    <th scope=""col"">Yanlış Cevap Sayısı</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 29 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
                 foreach (var sinavsonucu in sinavsonuclari)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
                       Write(sinavsonucu.SinavAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
                       Write(sinavsonucu.SoruSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
                       Write(sinavsonucu.DogruSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
                       Write(sinavsonucu.YanlisSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 37 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 41 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <center>\r\n            Herhangi bir sınav sonucu yok.<br />\r\n        </center>\r\n");
#nullable restore
#line 47 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Kullanici\SinavSonuclarim.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
