#pragma checksum "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fe557801aa7836af16101910910599afa2267a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Kullanicilar), @"mvc.1.0.view", @"/Views/Admin/Kullanicilar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fe557801aa7836af16101910910599afa2267a3", @"/Views/Admin/Kullanicilar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7c7dc880b7d044ee79c1c65c9edd9d1fc08fe3a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Kullanicilar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
  
    ViewData["Title"] = "Kullanıcılar";
    Layout = "_LayoutAdmin";
    List<Kullanici> kullanicilar = ViewBag.kullanicilar;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
 if (TempData["error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\" role=\"alert\">\r\n        ");
#nullable restore
#line 11 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
   Write(TempData["error"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 13 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Kullanici Listesi</h1>\r\n</div>\r\n<div class=\"container\">\r\n");
#nullable restore
#line 18 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
     if (kullanicilar.Count != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <th scope=""col"">Ad Soyad</th>
                    <th scope=""col"">Mail</th>
                    <th scope=""col"">Telefon</th>
                    <th scope=""col"">Şifre</th>
                    <th scope=""col""></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 31 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
                 foreach (var kullanici in kullanicilar)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
                       Write(kullanici.AdSoyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
                       Write(kullanici.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
                       Write(kullanici.Telefon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
                       Write(kullanici.Sifre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1197, "\"", 1240, 2);
            WriteAttributeValue("", 1204, "/Admin/KullaniciSil?Id=", 1204, 23, true);
#nullable restore
#line 39 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
WriteAttributeValue("", 1227, kullanici.Id, 1227, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" onclick=\"return confirm(\'Silmek istediğinizden emin misiniz?\');\">Sil</a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 46 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <center>\r\n            Herhangi bir kullanıcı yok.<br />\r\n        </center>\r\n");
#nullable restore
#line 52 "C:\Users\recep\source\repos\SinavTakipSistemi\PROJE\SinavTakipSistemi\Views\Admin\Kullanicilar.cshtml"
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
