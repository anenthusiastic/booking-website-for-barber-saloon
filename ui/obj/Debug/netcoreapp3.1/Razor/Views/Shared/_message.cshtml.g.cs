#pragma checksum "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shared\_message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aed661181991af273492ec1286098cde66395433"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__message), @"mvc.1.0.view", @"/Views/Shared/_message.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aed661181991af273492ec1286098cde66395433", @"/Views/Shared/_message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ec76be8e881572f4c0c9970be89117ef30d2282", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlertType>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div");
            BeginWriteAttribute("class", " class = \"", 80, "\"", 129, 5);
            WriteAttributeValue("", 90, "container", 90, 9, true);
            WriteAttributeValue(" ", 99, "alert", 100, 6, true);
            WriteAttributeValue(" ", 105, "alert-", 106, 7, true);
#nullable restore
#line 5 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shared\_message.cshtml"
WriteAttributeValue("", 112, Model.Alert, 112, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 124, "mt-5", 125, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <h4 class=\"alert-title\">");
#nullable restore
#line 6 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shared\_message.cshtml"
                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <p>");
#nullable restore
#line 7 "C:\Users\fatih\Desktop\barbersite\booking-website-for-barber-saloon\ui\Views\Shared\_message.cshtml"
          Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> \r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlertType> Html { get; private set; }
    }
}
#pragma warning restore 1591
