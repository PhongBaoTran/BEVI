#pragma checksum "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dc8861188dc3135ec53acef5083518995ebffb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_CheckOut), @"mvc.1.0.view", @"/Views/Cart/CheckOut.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc8861188dc3135ec53acef5083518995ebffb6", @"/Views/Cart/CheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6b55325b0ab971ba758bcc34a0cc77645e073f", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_CheckOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
  
    ViewData["Title"] = "CheckOut";
    Layout = "~/Views/Shared/_SecondLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Checkout Start -->
<div class=""container-fluid pt-5"">
    <div class=""row px-xl-5"">
        <div class=""col-lg-6"">
            <div class=""mb-4"">
                <h4 class=""font-weight-semi-bold mb-4"">THANH TOÁN</h4>
                <div class=""row"">
                    <div class=""col-md-6 form-group"">
                        <label>Tên người nhận</label>
                        <label>");
#nullable restore
#line 17 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                          Write(Model.user.fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </div>\r\n                    <div class=\"col-md-6 form-group\">\r\n                        <label>Số điện thoại</label>\r\n                        <label>\r\n                            ");
#nullable restore
#line 22 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                       Write(Model.user.phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </label>\r\n                    </div>\r\n                    <div class=\"col-md-12 form-group\">\r\n                        <label>Địa chỉ giao hàng</label>\r\n                        <label>");
#nullable restore
#line 27 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                          Write(Model.user.address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-lg-6"">
            <div class=""card border-secondary mb-5"">
                <div class=""card-header bg-secondary border-0"">
                    <h4 class=""font-weight-semi-bold m-0"">Hóa đơn </h4>
                </div>

                
            <div class=""card-body"">
                <div style=""overflow: auto;"">
                    <table class=""table table-bordered text-center mb-0"" style=""font-size: 13px;"">
                        <thead class=""bg-secondary text-dark"">
                            <tr>
                                <th colspan=""2"">Sản phẩm</th>
                                <th>Đơn giá</th>
                                <th>Số lượng</th>
                                <th>Giá</th>
                            </tr>
                        </thead>
                        <tbody class=""align-middle"">
");
#nullable restore
#line 51 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                             foreach (var item in Model.cart.items)
                            {
                                var sum = item.price * item.quantity;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"align-middle\"><img");
            BeginWriteAttribute("src", " src=\"", 2253, "\"", 2271, 1);
#nullable restore
#line 55 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
WriteAttributeValue("", 2259, item.img[0], 2259, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2272, "\"", 2278, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 40px; height: 40px;\"> </td>\r\n                                    <td class=\"align-middle\"> </td>\r\n                                    <td class=\"align-middle\">");
#nullable restore
#line 57 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                                                        Write(string.Format("{0:#,##0}", item.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"align-middle\">\r\n                                        <div class=\"mx-auto align-middle\">\r\n                                            ");
#nullable restore
#line 60 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                                       Write(item.quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </td>\r\n                                    <td class=\"align-middle\">");
#nullable restore
#line 63 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                                                        Write(string.Format("{0:#,##0}", sum));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 65 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>

                </div>
                <hr class=""mt-0"">
                <div class=""card-footer border-secondary bg-transparent"">
                    <div class=""d-flex justify-content-between mt-2"">
                        <h5 class=""font-weight-bold"">Số tiền phải trả cho hóa đơn</h5>
");
#nullable restore
#line 74 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                           
                            decimal sumall = 0;
                            foreach(var i in Model.cart.items)
                            {
                                sumall += i.price * i.quantity;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h5 class=\"font-weight-bold\">");
#nullable restore
#line 81 "E:\Projects\Shop_NET_Razor\Shop\Shop\Views\Cart\CheckOut.cshtml"
                                                Write(string.Format("{0:#,##0}", sumall));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    </div>\r\n                </div>\r\n                <hr style=\"border-top: 5px solid #0f893b\">\r\n            </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Checkout End -->\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderModel> Html { get; private set; }
    }
}
#pragma warning restore 1591