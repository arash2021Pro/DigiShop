#pragma checksum "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\ImageDocComponent\default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16fd8a7b9fbe36ac44e64850c7b95117c0174a39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ImageDocComponent_default), @"mvc.1.0.view", @"/Views/Shared/Components/ImageDocComponent/default.cshtml")]
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
#line 1 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\_ViewImports.cshtml"
using DigiShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\_ViewImports.cshtml"
using DigiShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16fd8a7b9fbe36ac44e64850c7b95117c0174a39", @"/Views/Shared/Components/ImageDocComponent/default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c875f52bea5bbee865626e651e99565f0dbb7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ImageDocComponent_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DigiShop.CoreBussiness.EfCoreDomains.Documents.Document>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class>\r\n    <div >\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 101, "\"", 157, 1);
#nullable restore
#line 4 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\ImageDocComponent\default.cshtml"
WriteAttributeValue("", 107, Url.Action("DownloadImage","Admin",new{Model.id}), 107, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  style=\"width:145px;height: 85px; border-radius: 0px\" class=\"img-circle elevation-2\" >\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DigiShop.CoreBussiness.EfCoreDomains.Documents.Document> Html { get; private set; }
    }
}
#pragma warning restore 1591
