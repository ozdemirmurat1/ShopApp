#pragma checksum "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shared\_resultmessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6338c8de6442e1fc1b056b4b138e26a7cd7fbd5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__resultmessage), @"mvc.1.0.view", @"/Views/Shared/_resultmessage.cshtml")]
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
#line 1 "D:\ShopApp2\ShopApp2\ShopApp2\Views\_ViewImports.cshtml"
using ShopApp2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ShopApp2\ShopApp2\ShopApp2\Views\_ViewImports.cshtml"
using ShopApp2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ShopApp2\ShopApp2\ShopApp2\Views\_ViewImports.cshtml"
using ShopApp2.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ShopApp2\ShopApp2\ShopApp2\Views\_ViewImports.cshtml"
using ShopApp2.Presentation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ShopApp2\ShopApp2\ShopApp2\Views\_ViewImports.cshtml"
using ShopApp2.Presentation.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6338c8de6442e1fc1b056b4b138e26a7cd7fbd5f", @"/Views/Shared/_resultmessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9b755d757b782bddc609dfae972041a643e3b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__resultmessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultMessage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 96, "\"", 126, 3);
            WriteAttributeValue("", 104, "alert", 104, 5, true);
            WriteAttributeValue(" ", 109, "alert-", 110, 7, true);
#nullable restore
#line 5 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shared\_resultmessage.cshtml"
WriteAttributeValue("", 116, Model.Css, 116, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <h4 class=\"alert-title\">");
#nullable restore
#line 6 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shared\_resultmessage.cshtml"
                                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <p>");
#nullable restore
#line 7 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shared\_resultmessage.cshtml"
              Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultMessage> Html { get; private set; }
    }
}
#pragma warning restore 1591