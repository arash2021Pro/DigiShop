#pragma checksum "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc7fe6a5de9860d05fc517ce58ac2c76231e52d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SubCategoryComponent_default), @"mvc.1.0.view", @"/Views/Shared/Components/SubCategoryComponent/default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc7fe6a5de9860d05fc517ce58ac2c76231e52d3", @"/Views/Shared/Components/SubCategoryComponent/default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c875f52bea5bbee865626e651e99565f0dbb7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SubCategoryComponent_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DigiShop.CoreBussiness.EfCoreDomains.StoreCategories.StoreCategory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1\" style=\"margin-top: 50px\">\r\n");
            WriteLiteral("        <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 266, "\"", 307, 1);
#nullable restore
#line 5 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
WriteAttributeValue("", 273, Url.Action("AddCategory","Admin"), 273, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">?????????? ???????? ????????</a>\r\n");
#nullable restore
#line 6 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
      
        for (int i = 0; i < Model.Count; i++)
        {
            
            if (Model[i].ParentId == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 487, "\"", 551, 1);
#nullable restore
#line 12 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
WriteAttributeValue("", 494, Url.Action("ModifyCategory","Admin",new{id=Model[i].id}), 494, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit sub-orange-link\"></i></a>\r\n                <ul>\r\n                    <h2><li style=\"color: #6f42c1\">");
#nullable restore
#line 14 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
                                              Write(Model[i].CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li></h2>\r\n                     <a");
            BeginWriteAttribute("href", " href=\"", 731, "\"", 789, 1);
#nullable restore
#line 15 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
WriteAttributeValue("", 738, Url.Action("AddChild","Admin",new{id=Model[i].id}), 738, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-plus-circle sub-green-link\"></i></a>\r\n                </ul>\r\n");
#nullable restore
#line 17 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
            }
            for (int s = 0 ; s < Model.Count;s++)
            {
                if (Model[s].ParentId == Model[i].id)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1045, "\"", 1109, 1);
#nullable restore
#line 22 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
WriteAttributeValue("", 1052, Url.Action("ModifyCategory","Admin",new{id=Model[s].id}), 1052, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit sub-orange-link\"></i></a>\r\n                    <ul>\r\n                        <h4><li>");
#nullable restore
#line 24 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
                           Write(Model[s].CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li></h4>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1277, "\"", 1335, 1);
#nullable restore
#line 25 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
WriteAttributeValue("", 1284, Url.Action("AddChild","Admin",new{id=Model[s].id}), 1284, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-plus-circle sub-green-link\"></i></a>\r\n                    </ul>\r\n");
#nullable restore
#line 27 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Shared\Components\SubCategoryComponent\default.cshtml"
                }
                
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DigiShop.CoreBussiness.EfCoreDomains.StoreCategories.StoreCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
