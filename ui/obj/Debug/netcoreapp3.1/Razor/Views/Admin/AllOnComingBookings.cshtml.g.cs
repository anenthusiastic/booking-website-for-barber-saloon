#pragma checksum "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8022b5229c74e5683a2706b80c514cf54730193f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AllOnComingBookings), @"mvc.1.0.view", @"/Views/Admin/AllOnComingBookings.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8022b5229c74e5683a2706b80c514cf54730193f", @"/Views/Admin/AllOnComingBookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ec76be8e881572f4c0c9970be89117ef30d2282", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AllOnComingBookings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookingListModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_message", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateBooking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("CSS", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css\">\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap4.min.js""></script>
    <script>    
        $(document).ready( function () {
            $('#myTable').DataTable();
        } );
    </script>
");
            }
            );
            WriteLiteral("<div class=\"bradcam_area breadcam_bg overlay2\">\r\n    <h3>Yaklaşan Rezervasyonlar</h3>\r\n</div>\r\n");
#nullable restore
#line 17 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
 if(TempData["message"]!=null){

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8022b5229c74e5683a2706b80c514cf54730193f6434", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 18 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
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
#line 19 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"d-flex justify-content-end mt-4\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8022b5229c74e5683a2706b80c514cf54730193f8455", async() => {
                WriteLiteral("REZERVASYON OLUŞTUR");
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
#line 30 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
             if (Model.Count() > 0)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-bordered"" id=""myTable"">
                    <thead>
                        <tr>
                            <td style=""width:50px;"">Kuaför</td>
                            <td style=""width:100px;"">Randevu Zamanı</td>
                            <td style=""width:50px;"">Müşteri</td>
                            <td style=""width:100px;"">Rezervasyon Oluşturulma Zamanı</td>
                            <td >Yapılacak İşlemler</td>
                            <td style=""width:50px;"">Alınacak Ücret</td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 45 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td><p class=\"text-capitalize font-weight-bold\">");
#nullable restore
#line 48 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                                                           Write(item.EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                                <td>");
#nullable restore
#line 49 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                               Write(item.BookingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><p class=\"text-capitalize font-weight-bold\">");
#nullable restore
#line 50 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                                                           Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n                                <td> ");
#nullable restore
#line 51 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                Write(item.CreatingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <ul class=\"text-capitalize font-weight-bold\">\r\n");
#nullable restore
#line 54 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                         foreach (var serviceName in item.serviceNames)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                           <li>");
#nullable restore
#line 56 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                          Write(serviceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 57 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </ul>\r\n                                </td>\r\n                                <td><i class=\"fas fa-lira-sign \"></i> ");
#nullable restore
#line 60 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                                                                 Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    \r\n                            </tr>\r\n");
#nullable restore
#line 63 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n\r\n                </table>\r\n");
#nullable restore
#line 68 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-warning\">\r\n                    <h4>Hiç Yaklaşan Rezervasyon Yok</h4>\r\n                </div>\r\n");
#nullable restore
#line 74 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Admin\AllOnComingBookings.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookingListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
