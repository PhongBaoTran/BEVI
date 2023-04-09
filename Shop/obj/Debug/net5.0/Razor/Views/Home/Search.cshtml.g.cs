#pragma checksum "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c9d6d5ed961e8583f5bc60045cb16bbb39f54fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
#line 1 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\_ViewImports.cshtml"
using Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\_ViewImports.cshtml"
using Shop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c9d6d5ed961e8583f5bc60045cb16bbb39f54fc", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/products.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
  
    Layout = "~/Views/Shared/_SecondLayout.cshtml";
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Products Start -->\r\n<div class=\"container-fluid pt-5\">\r\n    <div class=\"text-center mb-4\">\r\n        <h1 class=\"px-5 title\"><span class=\"px-2\">Sản phẩm bán chạy</span></h1>\r\n    </div>\r\n    <div class=\"row px-xl-5 pb-3\">\r\n");
#nullable restore
#line 13 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-lg-3 col-md-6 col-sm-12 pb-1"">
                <div class=""card product-item border-5 mb-4"">
                    <div class=""card-header product-img position-relative overflow-hidden bg-transparent border p-0"">
                        <img class=""img-fluid w-100"" style=""max-height: 250px""");
            BeginWriteAttribute("src", " src=\"", 729, "\"", 747, 1);
#nullable restore
#line 18 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
WriteAttributeValue("", 735, item.img[0], 735, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 748, "\"", 754, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"card-body border-left border-right text-center p-0 pt-4 pb-3\">\r\n                        <h6 class=\"mb-3 product-name\">");
#nullable restore
#line 21 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
                                                 Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <div class=\"d-flex justify-content-center\">\r\n                            <h6 class=\"product-price\">");
#nullable restore
#line 23 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
                                                 Write(string.Format("{0:#,##0}", item.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6><h6 class=\"text-muted ml-2\"><del>");
#nullable restore
#line 23 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
                                                                                                                              Write(string.Format("{0:#,##0}", item.lastprice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</del></h6>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer d-flex justify-content-between bg-light border\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1389, "\"", 1453, 1);
#nullable restore
#line 27 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
WriteAttributeValue("", 1396, Url.Action("ProductDetail","Home", new { id = item.id }), 1396, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm text-dark p-0\"><i class=\"fas fa-eye text-primary mr-1\"></i>Chi tiết</a>\r\n");
#nullable restore
#line 28 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
                         if (User.Identity.IsAuthenticated)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"btn btn-sm text-dark p-0\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1697, "\"", 1727, 3);
            WriteAttributeValue("", 1707, "Add1toCart(", 1707, 11, true);
#nullable restore
#line 30 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
WriteAttributeValue("", 1718, item.id, 1718, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1726, ")", 1726, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-shopping-cart text-primary mr-1\"></i>Thêm vào giỏ</a>\r\n");
#nullable restore
#line 31 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1915, "\"", 1949, 1);
#nullable restore
#line 34 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
WriteAttributeValue("", 1922, Url.Action("Login","Auth"), 1922, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm text-dark p-0\"><i class=\"fas fa-shopping-cart text-primary mr-1\"></i>Thêm vào giỏ</a>\r\n");
#nullable restore
#line 35 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 39 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\Search.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<!-- Products End -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c9d6d5ed961e8583f5bc60045cb16bbb39f54fc9322", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
