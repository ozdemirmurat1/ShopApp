#pragma checksum "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "705d4737fa898048b8ffafb14766ccd0b7cf7fae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Details), @"mvc.1.0.view", @"/Views/Shop/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"705d4737fa898048b8ffafb14766ccd0b7cf7fae", @"/Views/Shop/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9b755d757b782bddc609dfae972041a643e3b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailsModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 89, "\"", 123, 2);
            WriteAttributeValue("", 95, "/img/", 95, 5, true);
#nullable restore
#line 5 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
WriteAttributeValue("", 100, Model.Product.ImageUrl, 100, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 124, "\"", 149, 1);
#nullable restore
#line 5 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
WriteAttributeValue("", 130, Model.Product.Name, 130, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" />\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h1 class=\"mb-3\">\r\n            ");
#nullable restore
#line 9 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
       Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h1>\r\n        <hr />\r\n");
#nullable restore
#line 12 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
         foreach (var category in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a href=\"#\" class=\"btn btn-link p-0 mb-3\">");
#nullable restore
#line 14 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
                                                 Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 15 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"mb-3\">\r\n            <h4 class=\"text-primary mb-3\">\r\n                ");
#nullable restore
#line 19 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
           Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL\r\n            </h4>\r\n            <button type=\"submit\" class=\"btn btn-primary btn-lg\">Add to Cart</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <p class=\"p-3\">\r\n            ");
#nullable restore
#line 29 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Shop\Details.cshtml"
       Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
