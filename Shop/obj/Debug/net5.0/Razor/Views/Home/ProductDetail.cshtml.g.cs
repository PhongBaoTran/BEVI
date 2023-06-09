#pragma checksum "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb71e28665ca489fb3e9501b8de647b0232d3af8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductDetail), @"mvc.1.0.view", @"/Views/Home/ProductDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb71e28665ca489fb3e9501b8de647b0232d3af8", @"/Views/Home/ProductDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductModel>
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
#line 2 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
  
    ViewData["Title"] = "ProductDetail";
    Layout = "~/Views/Shared/_SecondLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Shop Detail Start -->
<div class=""container-fluid py-5"">
    <div class=""row px-xl-5"">
        <div class=""col-lg-5 pb-5"">
            <div id=""product-carousel"" class=""carousel slide"" data-ride=""carousel"">
                <div class=""carousel-inner border product-imgs"">
                    <div class=""carousel-item active"">
                        <img class=""w-100 h-100""");
            BeginWriteAttribute("src", " src=\"", 512, "\"", 531, 1);
#nullable restore
#line 14 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 518, Model.img[0], 518, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\">\r\n                    </div>\r\n");
#nullable restore
#line 16 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
                     for (int i = 1; i < Model.img.Count; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"carousel-item\">\r\n                            <img class=\"w-100 h-100\"");
            BeginWriteAttribute("src", " src=\"", 767, "\"", 786, 1);
#nullable restore
#line 19 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 773, Model.img[i], 773, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\">\r\n                        </div>\r\n");
#nullable restore
#line 21 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <a class=""carousel-control-prev"" href=""#product-carousel"" data-slide=""prev"">
                    <i class=""fa fa-2x fa-angle-left text-dark""></i>
                </a>
                <a class=""carousel-control-next"" href=""#product-carousel"" data-slide=""next"">
                    <i class=""fa fa-2x fa-angle-right text-dark""></i>
                </a>
            </div>
        </div>

        <div class=""col-lg-7 pb-5"">
            <h3 class=""font-weight-semi-bold"">");
#nullable restore
#line 33 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
                                         Write(Model.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <div style=\"display: flex\">\r\n                <h3 class=\"product-price\">");
#nullable restore
#line 35 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
                                     Write(string.Format("{0:#,##0}", Model.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h3 class=\"text-muted ml-2\"><del>");
#nullable restore
#line 36 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
                                            Write(string.Format("{0:#,##0}", Model.lastprice));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</del></h3>
            </div>
            <div class=""d-flex align-items-center mb-4 pt-2"">
                <div class=""input-group quantity mr-3"" style=""width: 130px;"">
                    <div class=""input-group-btn"">
                        <button class=""btn btn-primary btn-minus"">
                            <i class=""fa fa-minus""></i>
                        </button>
                    </div>
                    <input id=""txt_addmanytocart"" type=""text"" class=""form-control bg-secondary text-center"" value=""1"">
                    <div class=""input-group-btn"">
                        <button class=""btn btn-primary btn-plus"">
                            <i class=""fa fa-plus""></i>
                        </button>
                    </div>
                </div>
                <button class=""btn btn-primary px-3""");
            BeginWriteAttribute("onclick", " onclick=\"", 2463, "\"", 2493, 3);
            WriteAttributeValue("", 2473, "AddToCart(", 2473, 10, true);
#nullable restore
#line 52 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 2483, Model.id, 2483, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2492, ")", 2492, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-shopping-cart mr-1\"></i> Thêm vào giỏ</button>\r\n            </div>\r\n            <p class=\"mb-4\">");
#nullable restore
#line 54 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Home\ProductDetail.cshtml"
                       Write(Model.description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Shop Detail End -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eb71e28665ca489fb3e9501b8de647b0232d3af89087", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
