#pragma checksum "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "596cb6dd7e6daa00f551864c501dc6ed97c78250"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\Final\Final\Views\_ViewImports.cshtml"
using Final;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\Final\Final\Views\_ViewImports.cshtml"
using Final.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\Final\Final\Views\_ViewImports.cshtml"
using Final.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"596cb6dd7e6daa00f551864c501dc6ed97c78250", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03927bbc465e09d59c2465a5fe64ad9b297e3856", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "decrease", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "increase", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "letter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section id=""products"">
    <div class=""container"">
        <p style=""color: #6a6e49; font-size: 13px;""><a href=""/home/index"" class=""link"" style=""text-decoration: none; color: #6a6e49;"">Home</a> / Products</p>
        <h1 style=""font-family: 'Italiana', serif"">Products</h1>
        <div class=""row"">
            <div class=""col-lg-4 col-md-4"">
                <hr />
                <div class=""accordion accordion-flush"" id=""accordionFlushExample"">
                    <div class=""accordion-item"">
                        <h2 class=""accordion-header"" id=""flush-headingTwo"">
                            <button class=""accordion-button collapsed""
                                    type=""button""
                                    data-bs-toggle=""collapse""
                                    data-bs-target=""#flush-collapseTwo""
                                    aria-expanded=""false""
                                    aria-controls=""flush-collapseTwo"">
                                CATEGORY
    ");
            WriteLiteral(@"                        </button>
                        </h2>
                        <div id=""flush-collapseTwo""
                             class=""accordion-collapse collapse""
                             aria-labelledby=""flush-headingTwo""
                             data-bs-parent=""#accordionFlushExample"">
                            <div class=""accordion-body"">
");
#nullable restore
#line 27 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                 foreach (SubInfo item in Model.subInfos)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"form-check pt-1\">\r\n                                    <input class=\"form-check-input\"\r\n                                           type=\"checkbox\"");
            BeginWriteAttribute("value", "\r\n                                           value=\"", 1728, "\"", 1780, 0);
            EndWriteAttribute();
            WriteLiteral("\r\n                                           id=\"defaultcheck1\" />\r\n                                    <label class=\"form-check-label\" for=\"defaultcheck1\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1981, "\"", 2011, 2);
            WriteAttributeValue("", 1988, "/SubInfo/Index/", 1988, 15, true);
#nullable restore
#line 35 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
WriteAttributeValue("", 2003, item.Id, 2003, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-decoration:none; color:black;\">");
#nullable restore
#line 35 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                                                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </label>\r\n                                </div>\r\n");
#nullable restore
#line 38 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                    <div class=""accordion-item"">
                        <h2 class=""accordion-header"" id=""flush-headingTw"">
                            <button class=""accordion-button collapsed""
                                    type=""button""
                                    data-bs-toggle=""collapse""
                                    data-bs-target=""#flush-collapseTw""
                                    aria-expanded=""false""
                                    aria-controls=""flush-collapseTw"">
                                COLOR
                            </button>
                        </h2>
                        <div id=""flush-collapseTw""
                             class=""accordion-collapse collapse""
                             aria-labelledby=""flush-headingTw""
                             data-bs-parent=""#accordionFlushExample"">
                            <div class=""accordion-bo");
            WriteLiteral("dy\">\r\n");
#nullable restore
#line 58 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                 foreach (Color item in Model.colors)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"form-check\">\r\n                                        <input class=\"form-check-input\"\r\n                                               type=\"checkbox\"");
            BeginWriteAttribute("value", "\r\n                                               value=\"", 3526, "\"", 3582, 0);
            EndWriteAttribute();
            WriteLiteral("\r\n                                               id=\"defaultCheck1\" />\r\n                                        <label class=\"form-check-label\" for=\"defaultCheck1\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3795, "\"", 3823, 2);
            WriteAttributeValue("", 3802, "/Color/Index/", 3802, 13, true);
#nullable restore
#line 66 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
WriteAttributeValue("", 3815, item.Id, 3815, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-decoration:none; color:black;\">");
#nullable restore
#line 66 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </label>\r\n                                    </div>\r\n");
#nullable restore
#line 69 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                    <div class=""accordion-item"">
                        <h2 class=""accordion-header"" id=""flush-headingT"">
                            <button class=""accordion-button collapsed""
                                    type=""button""
                                    data-bs-toggle=""collapse""
                                    data-bs-target=""#flush-collapseT""
                                    aria-expanded=""false""
                                    aria-controls=""flush-collapseT"">
                                CUSTOMER RATING
                            </button>
                        </h2>
                        <div id=""flush-collapseT""
                             class=""accordion-collapse collapse""
                             aria-labelledby=""flush-headingT""
                             data-bs-parent=""#accordionFlushExample"">
                            <div class=""accordi");
            WriteLiteral("on-body\">\r\n");
#nullable restore
#line 89 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                 foreach (Rating item in Model.ratings)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"form-check\">\r\n                                        <input class=\"form-check-input\"\r\n                                               type=\"checkbox\"");
            BeginWriteAttribute("value", "\r\n                                               value=\"", 5353, "\"", 5409, 0);
            EndWriteAttribute();
            WriteLiteral("\r\n                                               id=\"defaultCheck1\" />\r\n                                        <label class=\"form-check-label\" for=\"defaultCheck1\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 5622, "\"", 5651, 2);
            WriteAttributeValue("", 5629, "/Rating/Index/", 5629, 14, true);
#nullable restore
#line 97 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
WriteAttributeValue("", 5643, item.Id, 5643, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-decoration: none; color: #6a6e49; \">");
#nullable restore
#line 97 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                                                                                                        Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </label>\r\n                                    </div>\r\n");
#nullable restore
#line 100 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                </div>
                <hr />
            </div>
            <div class=""col-md-8"">
                <hr class=""hr-sm"" />
                <div class=""row"">
                    <div class=""col-lg-4 col-md-6 col-12"">
                        <input id=""search"" type=""text"" placeholder=""Search..."" class=""form-control"" />
                    </div>
                    <div class=""col-md-4""></div>
                    <div class=""col-lg-4 col-md-12 col-12"">
                        <select style=""width: 100%""
                                class=""form-select mb-3""
                                aria-label=""Default select example""
                                id=""filter"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "596cb6dd7e6daa00f551864c501dc6ed97c7825015665", async() => {
                WriteLiteral("Default");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "596cb6dd7e6daa00f551864c501dc6ed97c7825017165", async() => {
                WriteLiteral("Short by price: low to high");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "596cb6dd7e6daa00f551864c501dc6ed97c7825018374", async() => {
                WriteLiteral("Short by price: high to low");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "596cb6dd7e6daa00f551864c501dc6ed97c7825019583", async() => {
                WriteLiteral("Short by name");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </select>\r\n                    </div>\r\n                    <div class=\"row product-container\" id=\"search-results\">\r\n                    </div>\r\n");
#nullable restore
#line 127 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                     foreach (Product item in Model.products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-4 col-md-6 col-6 mt-4\">\r\n                            <div class=\"card inner2\">\r\n                                <div class=\"inner\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "596cb6dd7e6daa00f551864c501dc6ed97c7825021412", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7455, "~/admin/assets/img/", 7455, 19, true);
#nullable restore
#line 132 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
AddHtmlAttributeValue("", 7474, item.Image, 7474, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <div>\r\n                                        <a class=\"shop-btn btn btn-outline-dark select-btn1\"");
            BeginWriteAttribute("href", "\r\n                                           href=\"", 7753, "\"", 7828, 2);
            WriteAttributeValue("", 7804, "/product/select/", 7804, 16, true);
#nullable restore
#line 137 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
WriteAttributeValue("", 7820, item.Id, 7820, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                                           data-aos=""fade-up""
                                           data-aos-delay=""700""
                                           type=""button"">SELECT OPTION</a>
                                    </div>
                                </div>
                                <div class=""card-body text-center"">
                                    <h4 class=""card-text pt-3"">");
#nullable restore
#line 144 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    <span>$");
#nullable restore
#line 145 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                                      Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> | \r\n                                    <a style=\"color:black;\"");
            BeginWriteAttribute("href", "\r\n                                       href=\"", 8393, "\"", 8464, 2);
            WriteAttributeValue("", 8440, "/product/detail/", 8440, 16, true);
#nullable restore
#line 147 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
WriteAttributeValue("", 8456, item.Id, 8456, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                                       data-aos=""fade-up""
                                       data-aos-delay=""700""
                                       type=""button"">
                                        <i class=""bi bi-heart""></i>
                                    </a>
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 156 "C:\Users\HP\Desktop\Final\Final\Views\Product\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
