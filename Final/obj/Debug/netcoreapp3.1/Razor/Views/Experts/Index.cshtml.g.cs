#pragma checksum "C:\Users\HP\Documents\Final\Final\Views\Experts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc62fec0c631749342bc7c402a9e157700539689"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Experts_Index), @"mvc.1.0.view", @"/Views/Experts/Index.cshtml")]
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
#line 1 "C:\Users\HP\Documents\Final\Final\Views\_ViewImports.cshtml"
using Final;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Documents\Final\Final\Views\_ViewImports.cshtml"
using Final.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Documents\Final\Final\Views\_ViewImports.cshtml"
using Final.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc62fec0c631749342bc7c402a9e157700539689", @"/Views/Experts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03927bbc465e09d59c2465a5fe64ad9b297e3856", @"/Views/_ViewImports.cshtml")]
    public class Views_Experts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/experts/subject"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<section id=""login"" style=""margin-top: 170px!important;"">
    <div class=""container information"">
        <div class=""row"">
            <div class=""col-lg-6 col-md-11 col-11 m-auto dashboard"">
                <h1 class=""pb-5 text-center"" style=""font-family: 'Italiana', serif;"">Speak to our experts</h1>
                <div class=""inner1"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc62fec0c631749342bc7c402a9e1577005396894353", async() => {
                WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-lg-6 col-md-6\">\r\n                                <label");
                BeginWriteAttribute("for", " for=\"", 557, "\"", 563, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""pb-2"">First name *</label>
                                <input class=""form-control form-control-lg mb-2""
                                       type=""text"" name=""name""/>
                            </div>
                            <div class=""col-lg-6 col-md-6"">
                                <label");
                BeginWriteAttribute("for", " for=\"", 883, "\"", 889, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""pb-2"">Last name *</label>
                                <input class=""form-control form-control-lg mb-2""
                                       type=""text"" name=""surname""/>
                            </div>
                            <div class=""col-lg-6 col-md-6"">
                                <label");
                BeginWriteAttribute("for", " for=\"", 1211, "\"", 1217, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""pb-2"">Phone number *</label>
                                <input class=""form-control form-control-lg mb-2""
                                       type=""tel"" name=""phone""/>
                            </div>
                            <div class=""col-lg-6 col-md-6"">
                                <label");
                BeginWriteAttribute("for", " for=\"", 1539, "\"", 1545, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""pb-2"">Email address *</label>
                                <input class=""form-control form-control-lg mb-2""
                                       type=""email"" name=""email""/>
                            </div>
                        </div>
                        <label");
                BeginWriteAttribute("for", " for=\"", 1833, "\"", 1839, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"pb-2\">Subject *</label>\r\n                        <input class=\"form-control form-control-lg mb-2\" type=\"text\" name=\"subject\"/>\r\n                        <label");
                BeginWriteAttribute("for", " for=\"", 2006, "\"", 2012, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""pb-2"">Your message *</label>
                        <textarea class=""form-control mb-5"" id=""exampleFormControlTextarea1"" rows=""4"" name=""message""></textarea>
                        <input type=""submit"" value=""SUBMIT"" class=""shop-btn btn btn-outline-dark login-btn m-auto mb-3"" style=""border-radius: 20px!important;"" />
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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