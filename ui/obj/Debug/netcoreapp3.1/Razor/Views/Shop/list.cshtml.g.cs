#pragma checksum "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba531009057826ff7e560534d03e18bb49c70857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_list), @"mvc.1.0.view", @"/Views/Shop/list.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba531009057826ff7e560534d03e18bb49c70857", @"/Views/Shop/list.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ec76be8e881572f4c0c9970be89117ef30d2282", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_list : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline m-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"bradcam_area breadcam_bg overlay2\">\r\n        <h3>Mağaza</h3>\r\n    </div>\r\n<div class=\"container my-5 \">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3 \">\r\n            ");
#nullable restore
#line 8 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
       Write(await Component.InvokeAsync("CategoryList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-9 \">\r\n");
#nullable restore
#line 11 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
             if(Model.PagingInfo.TotalItems>0){


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card mb-4\">\r\n                        <div class=\"card-header font-weight-bold\">\r\n                            Search\r\n                        </div>\r\n                        <div class=\"p-4\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba531009057826ff7e560534d03e18bb49c708576254", async() => {
                WriteLiteral(@"
                                <input name=""search"" type=""search"" class=""form-control"" placeholder=""Search for..."" aria-label=""Search"">
                                <div class=""input-group-btn"">
                                    <button class=""btn btn-success"" type=""submit"">Go!</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n            <div class=\"row \">\r\n");
#nullable restore
#line 27 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                 foreach (var product in Model.Products)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ba531009057826ff7e560534d03e18bb49c708578434", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 29 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => product);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 30 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <nav aria-label=\"Page navigation example \" class=\"d-flex mt-5 justify content\">\r\n                <ul class=\"pagination\">\r\n                \r\n");
#nullable restore
#line 35 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                     if(String.IsNullOrEmpty(Model.PagingInfo.CurrentCategory)){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 1568, "\"", 1634, 2);
            WriteAttributeValue("", 1576, "page-item", 1576, 9, true);
#nullable restore
#line 36 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("  ", 1585, Model.PagingInfo.CurrentPage>1?"":"disabled", 1587, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1656, "\"", 1712, 2);
            WriteAttributeValue("", 1663, "/products/?page=", 1663, 16, true);
#nullable restore
#line 36 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 1679, Model.PagingInfo.CurrentPage-1, 1679, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Önceki</a></li>\r\n");
#nullable restore
#line 37 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                         for (int i = 0; i < Model.PagingInfo.TotalPages(); i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 1879, "\"", 1946, 2);
            WriteAttributeValue("", 1887, "page-item", 1887, 9, true);
#nullable restore
#line 39 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("  ", 1896, Model.PagingInfo.CurrentPage==i+1?"active":"", 1898, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1968, "\"", 1997, 2);
            WriteAttributeValue("", 1975, "/products/?page=", 1975, 16, true);
#nullable restore
#line 39 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 1991, i+1, 1991, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 39 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                                                                                                                                                       Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 40 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 2076, "\"", 2173, 3);
            WriteAttributeValue("", 2084, "page-item", 2084, 9, true);
#nullable restore
#line 42 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue(" ", 2093, Model.PagingInfo.TotalPages()>=Model.PagingInfo.CurrentPage+1?"":"disabled", 2094, 78, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2172, "", 2173, 1, true);
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2195, "\"", 2251, 2);
            WriteAttributeValue("", 2202, "/products/?page=", 2202, 16, true);
#nullable restore
#line 42 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 2218, Model.PagingInfo.CurrentPage+1, 2218, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sonraki</a></li>\r\n");
#nullable restore
#line 43 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                    }
                    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 2348, "\"", 2414, 3);
            WriteAttributeValue("", 2356, "page-item", 2356, 9, true);
#nullable restore
#line 45 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue(" ", 2365, Model.PagingInfo.CurrentPage>1?"":"disabled", 2366, 47, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2413, "", 2414, 1, true);
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2436, "\"", 2526, 4);
            WriteAttributeValue("", 2443, "/products/", 2443, 10, true);
#nullable restore
#line 45 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 2453, Model.PagingInfo.CurrentCategory, 2453, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2486, "/?page=", 2486, 7, true);
#nullable restore
#line 45 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 2493, Model.PagingInfo.CurrentPage-1, 2493, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Önceki</a></li>\r\n");
#nullable restore
#line 46 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                         for (int i = 0; i < Model.PagingInfo.TotalPages(); i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 2693, "\"", 2759, 2);
            WriteAttributeValue("", 2701, "page-item", 2701, 9, true);
#nullable restore
#line 48 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue(" ", 2710, Model.PagingInfo.CurrentPage==i+1?"active":"", 2711, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2781, "\"", 2844, 4);
            WriteAttributeValue("", 2788, "/products/", 2788, 10, true);
#nullable restore
#line 48 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 2798, Model.PagingInfo.CurrentCategory, 2798, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2831, "/?page=", 2831, 7, true);
#nullable restore
#line 48 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 2838, i+1, 2838, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 48 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                                                                                                                                                                                        Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 49 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 2923, "\"", 3020, 2);
            WriteAttributeValue("", 2931, "page-item", 2931, 9, true);
#nullable restore
#line 51 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("  ", 2940, Model.PagingInfo.TotalPages()>=Model.PagingInfo.CurrentPage+1?"":"disabled", 2942, 78, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3042, "\"", 3132, 4);
            WriteAttributeValue("", 3049, "/products/", 3049, 10, true);
#nullable restore
#line 51 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 3059, Model.PagingInfo.CurrentCategory, 3059, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3092, "/?page=", 3092, 7, true);
#nullable restore
#line 51 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
WriteAttributeValue("", 3099, Model.PagingInfo.CurrentPage+1, 3099, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sonraki</a></li>\r\n");
#nullable restore
#line 52 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                </ul>\r\n            </nav>\r\n");
#nullable restore
#line 56 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
            }
            else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                 <div class=\"alert alert-warning\">\r\n                    <h4>Bu kategoride ürün yok!</h4>\r\n                </div>\r\n");
#nullable restore
#line 61 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shop\list.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n     \r\n</div>\r\n");
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
