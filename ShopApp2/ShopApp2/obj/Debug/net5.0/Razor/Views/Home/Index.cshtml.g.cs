#pragma checksum "D:\ShopApp2\ShopApp2\ShopApp2\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a77afb94ef6f286d5b137207ecc664049b4cc7eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a77afb94ef6f286d5b137207ecc664049b4cc7eb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9b755d757b782bddc609dfae972041a643e3b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopApp2.Presentation.Models.ProductListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");
#nullable restore
#line 5 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Home\Index.cshtml"
   Write(await Component.InvokeAsync("CategoryList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        ");
#nullable restore
#line 8 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Home\Index.cshtml"
   Write(await Html.PartialAsync("_slider"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 11 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Home\Index.cshtml"
             foreach (var p in Model.Products)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("_product",p));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\ShopApp2\ShopApp2\ShopApp2\Views\Home\Index.cshtml"
                                                      
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>        \r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopApp2.Presentation.Models.ProductListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
