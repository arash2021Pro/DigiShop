#pragma checksum "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b604943d9623bc06cce7e0b1a6f7bda1909befea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DocList), @"mvc.1.0.view", @"/Views/Admin/DocList.cshtml")]
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
#nullable restore
#line 1 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
using DigiShop.CoreBussiness.EfCoreDomains.Documents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b604943d9623bc06cce7e0b1a6f7bda1909befea", @"/Views/Admin/DocList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c875f52bea5bbee865626e651e99565f0dbb7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DocList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DigiShop.CoreBussiness.EfCoreDomains.Documents.Document>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-bordered table-hover   table-dark"" id=""mytable"">
    <thead>
    <tr>
        <th>ادرس</th>
        <th>شماره منزل</th>
        <th>کد ملی</th>
        <th>عکس مدارک</th>
        <th>وضعیت</th>
        <th>اقدامات</th>
    </tr>
    </thead>
    <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 434, "\"", 473, 1);
#nullable restore
#line 14 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
WriteAttributeValue("", 441, Url.Action("DashBoard","Admin"), 441, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">برگشت</a>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
      
        foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
               Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
               Write(item.Homephone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
               Write(item.NationalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
               Write(await Component.InvokeAsync("ImageDocComponent", item.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 24 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                  
                    if (item.AuthStatus == AuthStatus.None)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><span class=\"bg bg-secondary\">");
#nullable restore
#line 27 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                                                     Write(item.AuthStatus.ConvertStatus(item.AuthStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 28 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                    }
                    else if (item.AuthStatus == AuthStatus.Accepted)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><span class=\"bg bg-success\">");
#nullable restore
#line 31 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                                                   Write(item.AuthStatus.ConvertStatus(item.AuthStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 32 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><span class=\"bg bg-danger\">");
#nullable restore
#line 35 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                                                  Write(item.AuthStatus.ConvertStatus(item.AuthStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 36 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1517, "\"", 1573, 1);
#nullable restore
#line 38 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
WriteAttributeValue("", 1524, Url.Action("DocDetails","Admin",new{id=item.id}), 1524, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">جزییات</a></td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Admin\DocList.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DigiShop.CoreBussiness.EfCoreDomains.Documents.Document>> Html { get; private set; }
    }
}
#pragma warning restore 1591
