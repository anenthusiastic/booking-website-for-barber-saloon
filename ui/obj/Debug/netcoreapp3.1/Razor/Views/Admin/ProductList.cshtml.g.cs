#pragma checksum "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dabe9653bddb72a3bfa076567a3563be4b6f037"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ProductList), @"mvc.1.0.view", @"/Views/Admin/ProductList.cshtml")]
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
#line 1 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\_ViewImports.cshtml"
using entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\_ViewImports.cshtml"
using ui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\_ViewImports.cshtml"
using ui.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\_ViewImports.cshtml"
using ui.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dabe9653bddb72a3bfa076567a3563be4b6f037", @"/Views/Admin/ProductList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ec76be8e881572f4c0c9970be89117ef30d2282", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ProductList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_message", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/deleteproduct"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"bradcam_area breadcam_bg overlay2\">\r\n    <h3>Admin Ürünler</h3>\r\n</div>\r\n");
#nullable restore
#line 6 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
 if(TempData["message"]!=null){

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1dabe9653bddb72a3bfa076567a3563be4b6f0377497", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (TempData.Get<AlertType>("message"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"d-flex justify-content-end mt-4\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dabe9653bddb72a3bfa076567a3563be4b6f0379500", async() => {
                WriteLiteral("ÜRÜN EKLE");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </div>\r\n            <hr />\r\n\r\n\r\n");
#nullable restore
#line 19 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
             if (Model.Products.Count() > 0)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-bordered"">
                    <thead>
                        <tr>
                            <td style=""width:30px;"">Id</td>
                            <td style=""width:100px;"">Resim</td>
                            <td>İsim</td>
                            <td style=""width:90px;"">Fiyat</td>
                            <td style=""width:50px;"">Stokta Var</td>
                            <td style=""width:220px;""></td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 34 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                         foreach (var item in Model.Products)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                               Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1dabe9653bddb72a3bfa076567a3563be4b6f03712581", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1410, "~/img/products/", 1410, 15, true);
#nullable restore
#line 39 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
AddHtmlAttributeValue("", 1425, item.imageUrl, 1425, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td><p class=\"text-capitalize font-weight-bold\">");
#nullable restore
#line 41 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                                                                           Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                                <td><i class=\"fas fa-lira-sign \"></i> ");
#nullable restore
#line 42 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                                                                 Write(item.price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 43 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                                     if(item.isApproved){

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <i class=\"fas fa-check-circle \" style=\"color:green;\"></i>\r\n");
#nullable restore
#line 45 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                                    }
                                    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <i class=\"fas fa-times-circle\" style=\"color:red;\"></i>\r\n");
#nullable restore
#line 48 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td>\r\n                                    <a class=\"btn btn-primary btn-sm mr-2 mb-md-0 mb-3\"");
            BeginWriteAttribute("href", " href=\"", 2219, "\"", 2250, 2);
            WriteAttributeValue("", 2226, "/admin/products/", 2226, 16, true);
#nullable restore
#line 51 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
WriteAttributeValue("", 2242, item.id, 2242, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Düzenle</a>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dabe9653bddb72a3bfa076567a3563be4b6f03716743", async() => {
                WriteLiteral("\r\n                                        <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 2454, "\"", 2470, 1);
#nullable restore
#line 53 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
WriteAttributeValue("", 2462, item.id, 2462, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                        <button type=\"submit\" class=\"btn btn-danger btn-sm\">Ürünü Sil</button>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 58 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n\r\n                </table>\r\n");
#nullable restore
#line 63 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-warning\">\r\n                    <h4>Ürün Yok</h4>\r\n                </div>\r\n");
#nullable restore
#line 69 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\ProductList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
