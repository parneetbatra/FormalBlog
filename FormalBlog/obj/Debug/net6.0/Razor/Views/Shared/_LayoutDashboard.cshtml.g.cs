#pragma checksum "D:\Project\Database\New folder\FormalBlog\FormalBlog\Views\Shared\_LayoutDashboard.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "35c890cae44ba4ba5652a0403693bc63a49afb6780f9ecf3d5f8f52a5d69bfba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutDashboard), @"mvc.1.0.view", @"/Views/Shared/_LayoutDashboard.cshtml")]
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
#line 1 "D:\Project\Database\New folder\FormalBlog\FormalBlog\Views\_ViewImports.cshtml"
using FormalBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Database\New folder\FormalBlog\FormalBlog\Views\_ViewImports.cshtml"
using FormalBlog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"35c890cae44ba4ba5652a0403693bc63a49afb6780f9ecf3d5f8f52a5d69bfba", @"/Views/Shared/_LayoutDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4ee3aa5dd7ec586e3b2a9e2bd5716d58a90b9c0bb54d6c54c8474523efd746c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35c890cae44ba4ba5652a0403693bc63a49afb6780f9ecf3d5f8f52a5d69bfba3376", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>");
#nullable restore
#line 6 "D:\Project\Database\New folder\FormalBlog\FormalBlog\Views\Shared\_LayoutDashboard.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35c890cae44ba4ba5652a0403693bc63a49afb6780f9ecf3d5f8f52a5d69bfba4688", async() => {
                WriteLiteral(@"
    <header class=""navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow"">
        <a class=""navbar-brand col-md-3 col-lg-2 me-0 px-3"" href=""#"">Company name</a>
        <button class=""navbar-toggler position-absolute d-md-none collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#sidebarMenu"" aria-controls=""sidebarMenu"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>
        <input class=""form-control form-control-dark w-100"" type=""text"" placeholder=""Search"" aria-label=""Search"">
        <ul class=""navbar-nav px-3"">
            <li class=""nav-item text-nowrap"">
                <a class=""nav-link"" href=""#"">Sign out</a>
            </li>
        </ul>
    </header>

    <div class=""container-fluid"">
        <div class=""row"">
            <nav id=""sidebarMenu"" class=""col-md-3 col-lg-2 d-md-block bg-light sidebar collapse"">
                <div class=""position-sticky pt-3"">
                    <u");
                WriteLiteral(@"l class=""nav flex-column"">
                        <li class=""nav-item"">
                            <a class=""nav-link active"" aria-current=""page"" href=""#"">
                                <span data-feather=""home""></span>
                                Dashboard
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""file""></span>
                                Orders
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""shopping-cart""></span>
                                Products
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
               ");
                WriteLiteral(@"                 <span data-feather=""users""></span>
                                Customers
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""bar-chart-2""></span>
                                Reports
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""layers""></span>
                                Integrations
                            </a>
                        </li>
                    </ul>

                    <h6 class=""sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted"">
                        <span>Saved reports</span>
                        <a class=""link-secondary"" href=""#"" aria-label=""Add a new rep");
                WriteLiteral(@"ort"">
                            <span data-feather=""plus-circle""></span>
                        </a>
                    </h6>
                    <ul class=""nav flex-column mb-2"">
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""file-text""></span>
                                Current month
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""file-text""></span>
                                Last quarter
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""file-text""></span>
                                Social engagement
                           ");
                WriteLiteral(@" </a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"">
                                <span data-feather=""file-text""></span>
                                Year-end sale
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>

            <main class=""col-md-9 ms-sm-auto col-lg-10 px-md-4"">
                ");
#nullable restore
#line 101 "D:\Project\Database\New folder\FormalBlog\FormalBlog\Views\Shared\_LayoutDashboard.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("                \r\n            </main>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591