#pragma checksum "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Manager\ManageRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e68aa936f43b1a2fc1c3a247030f90ad72710fb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_ManageRole), @"mvc.1.0.view", @"/Views/Manager/ManageRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e68aa936f43b1a2fc1c3a247030f90ad72710fb5", @"/Views/Manager/ManageRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c875f52bea5bbee865626e651e99565f0dbb7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_ManageRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Role>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ManageRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav class=""navbar navbar-expand-lg navbar-light nav"" style=""background-color:whitesmoke"">
    <div class=""collapse navbar-collapse"" id=""bs-example-navbar-collapse-1"">
        <ul class=""navbar-nav"">
      
            <li class=""nav-item dropdown"">
                <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownMenuLink"" data-toggle=""dropdown""><span class=""bg bg-light"">زیر گروه</span></a>
                <div class=""dropdown-menu bg bg-light "" aria-labelledby=""navbarDropdownMenuLink"">
                    <a class=""dropdown-item bg bg-light""");
            BeginWriteAttribute("href", " href=\"", 643, "\"", 682, 1);
#nullable restore
#line 9 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Manager\ManageRole.cshtml"
WriteAttributeValue("", 650, Url.Action("AddRole","Manager"), 650, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">اضافه سازی نقش</a> <a class=""dropdown-item"" href=""#"">مدیریت نقش</a> <a class=""dropdown-item"" href=""#""></a>
                    <div class=""dropdown-divider"">
                    </div> <a class=""dropdown-item"" href=""#""></a>
                </div>
            </li>
        </ul>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e68aa936f43b1a2fc1c3a247030f90ad72710fb55820", async() => {
                WriteLiteral(@"
            <input class=""form-control mr-sm-2 btn-outline-light"" type=""text"" name=""searchvalue"" placeholder=""جست و جو ...""/>
            <button class=""btn btn-primary -2 my-sm-0"" type=""submit"">
                جست و جو
            </button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</nav>


<div>
    <table class=""table table-bordered table-hover  table-light table-bordered"" id=""myTable"" >
        <thead>
        <tr>
            <th>نام دسترسی</th>
            <th>عملیات</th>
        </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 34 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Manager\ManageRole.cshtml"
          
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 38 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Manager\ManageRole.cshtml"
                   Write(item.rolename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1788, "\"", 1851, 1);
#nullable restore
#line 40 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Manager\ManageRole.cshtml"
WriteAttributeValue("", 1795, Url.Action("ModifyRole", "Manager", new {id = item.id}), 1795, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><button class=\"btn btn-primary\">اصلاح نقش</button></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\admin\RiderProjects\DigiShop\DigiShop\Views\Manager\ManageRole.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions.Role>> Html { get; private set; }
    }
}
#pragma warning restore 1591