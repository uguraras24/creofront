#pragma checksum "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\Login\ActivateAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0aa3b52ee32ef298893bdbe5c530203f4d67e95f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_ActivateAccount), @"mvc.1.0.view", @"/Views/Login/ActivateAccount.cshtml")]
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
#line 1 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\_ViewImports.cshtml"
using WebApplication4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0aa3b52ee32ef298893bdbe5c530203f4d67e95f", @"/Views/Login/ActivateAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad7b7b34f958353904e84adcda99bf7ec2b4afdf", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_ActivateAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\Login\ActivateAccount.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0aa3b52ee32ef298893bdbe5c530203f4d67e95f3931", async() => {
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">

    <link rel=""shortcut icon"" href=""https://creomars.blob.core.windows.net/src/wwwroot/favicon.ico"">
    <meta name=""viewport"" content=""width=device-width,initial-scale=1"">
    <meta name=""theme-color"" content=""#000000"">
    <link rel=""manifest"" href=""https://creomars.blob.core.windows.net/src/wwwroot/js/manifest.json>
    <link rel=""stylesheet"" href=""https://creomars.blob.core.windows.net/src/wwwroot/css/semantic.min.css"">
    <script src=""https://creomars.blob.core.windows.net/src/wwwroot/lib/jquery/dist/jquery.min.js""></script>
    <script src=""https://creomars.blob.core.windows.net/src/wwwroot/js/custom.js""></script>
    <script src=""https://creomars.blob.core.windows.net/src/wwwroot/js/pwdwidget.js""></script>

");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0aa3b52ee32ef298893bdbe5c530203f4d67e95f5734", async() => {
                WriteLiteral(@"
    <div id=""root"">
        <div id=""notification-container""></div><div id=""modal-container""></div><div class=""ui centered internally celled grid h-100vh"">
            <div class=""row"">
                <div class=""middle aligned eight wide computer sixteen wide mobile eight wide tablet column"">
                    <div class=""ui very padded left aligned segment fade visible transition""");
                BeginWriteAttribute("style", " style=\"", 1301, "\"", 1309, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""ui inverted dimmer""><div class=""content""><div class=""ui loader""></div></div></div><div class=""stc-logo"">
                            <svg id=""Layer_1"" x=""0px"" y=""0px"" viewBox=""0 0 1062.6 194.4"" xml:space=""preserve""><style type=""text/css"">
                                                                                                                  .st0 {
                                                                                                                      fill: none;
                                                                                                                  }
</style><path class=""st0"" d=""M0,0""></path><g><path d=""M758.8,54.2c2.1,40.4-120.3,79.7-273.4,87.7c-89.3,4.7-169.4-2.3-221-17c50.3,19.7,144.3,29.8,251.4,24.2 c158.1-8.3,284.5-47.8,282.4-88.2c-1-19.3-31.3-35.4-79.9-46c-2.2-0.5-3,2.8-0.9,3.6C742.9,28.3,758,40.4,758.8,54.2z""></path><path d=""M609.3,166.2l-3.9,22.7c-0.6,3.2-3.3,5.5-6.5,5.5h-77.1c-19.8,0-33.1-16-29.6-35.9l27-152.");
                WriteLiteral(@"9c0.6-3.2,3.3-5.5,6.5-5.5h22.4 c4.1,0,7.2,3.7,6.5,7.8l-3.7,20.3c-0.7,4.1,2.4,7.8,6.5,7.8h27.9c4.8,0,8,5.1,6,9.4L585,68.3c-1.1,2.3-3.4,3.8-6,3.8h-30.2 c-3.2,0-6,2.3-6.5,5.5l-12.9,73.6c-0.8,4.1,1.9,7.3,6,7.3h67.5C606.9,158.5,610,162.2,609.3,166.2z""></path><path d=""M691.1,188.4c-0.6,3.5-3.6,6-7.1,6h-77.6c-19.8,0-33.1-16-29.6-35.9L592,72.1C595.5,52,614.3,36,634.1,36h60.6 c5.2,0,8.7,5.3,6.6,10.1L695,67.8c-1.1,2.6-3.7,4.4-6.6,4.4h-53.2c-4.1,0-7.9,3-8.7,7.1l-12.5,72c-0.8,4.1,1.9,7.3,6,7.3h67.8 c4.5,0,7.9,4,7.1,8.5L691.1,188.4z""></path><path d=""M581.6,35.9h-187c-29.7,0-41.6,13.1-45.1,33.2l-4.3,25c-3.5,19.8,12.5,39.1,32.3,39.1h64.9c4.1,0,6.5,3.3,6,7.1l-1.9,10.9 c-0.8,4.1-4.3,7.3-8.4,7.3H289.6v35.9h149.3c20.1,0,38.9-16,42.4-35.9l4.3-25.3c3.5-19.8-9.5-36.1-29.6-36.1h-64.7 c-4.1,0-6.8-3.3-6.2-7.1l1.9-10.9c0.8-4.1,4.6-7.1,8.7-7.1h178.6c2.1,0,4.1-1.2,5-3.2l7.3-25C588.3,40.2,585.7,35.9,581.6,35.9z""></path></g></svg>
                        </div>
                        <h5 class=""ui purple center aligned header uppercase");
                WriteLiteral("\">Activate my account</h5>\r\n                        <p class=\"text-center\">You are entering the STC Digital Securities Platform,<br>please set your password to activate your account</p>\r\n");
#nullable restore
#line 36 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\Login\ActivateAccount.cshtml"
                         using (Html.BeginForm("NewPassword", "Login", FormMethod.Post, new { @class = "ui form", id = "acForm" }))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"required field\" id=\"rfErrorP\">\r\n                                <label>New password</label>\r\n                                <div class=\"ui left icon input\">\r\n                                    ");
#nullable restore
#line 41 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\Login\ActivateAccount.cshtml"
                               Write(Html.Password("password", null, new { id = "password", placeholder = "●●●●●●", required = "required" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    <i aria-hidden=""true"" class=""lock icon""></i>
                                </div>
                                <div class=""ui pointing above prompt label"" id=""rfErrorTxt"" style=""display:none"">Password is not secure enough</div>
                            </div>
                            <div class=""required field"" id=""rfErrorPC"">
                                <label>Confirm password</label>
                                <div class=""ui left icon input"">
                                    ");
#nullable restore
#line 49 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\Login\ActivateAccount.cshtml"
                               Write(Html.Password("password", null, new { id = "password", placeholder = "●●●●●●", required = "required" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    <i aria-hidden=""true"" class=""lock icon""></i>
                                </div>
                                <div class=""ui pointing above prompt label"" id=""rfErrorMatchTxt"" style=""display:none"">Passwords do not match</div>
                            </div>
                            <div class=""field"">
                                <div class=""ui grid"">
                                    <div class=""two column row"">
                                        <div class=""middle aligned column"">
                                            <div class=""ui sub header"">Password strength</div>
                                        </div>
                                        <div class=""right aligned column"">
                                            <div class=""ui red tiny progress"" id=""prBar"" data-percent=""0"" style=""margin: 5px 0px;"">
                                                <div class=""bar"" id=""barW"" style=""width: 0%;"">
                    ");
                WriteLiteral(@"                            </div>
                                            </div>
                                            <small id=""prTxt"">Too Weak</small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""field"">
                                <button type=""submit"" class=""ui purple fluid button"" tabindex=""-1"">Activate my account</button>
                            </div>
");
#nullable restore
#line 73 "C:\Users\90534\Desktop\webb\creosafe_front-master\WebApplication4\Views\Login\ActivateAccount.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
    !function (e) {
            function r(r) {
                for (var n, f, i = r[0], l = r[1], a = r[2], p = 0, s = [];
                    p < i.length;
                    p++)f = i[p], Object.prototype.hasOwnProperty.call(o, f) && o[f] && s.push(o[f][0]), o[f] = 0;
                for (n in l) Object.prototype.hasOwnProperty.call(l, n) && (e[n] = l[n]);
                for (c && c(r);
                    s.length;
                )s.shift()();
                return u.push.apply(u, a || []), t()
            }
            function t() {
                for (var e, r = 0;
                    r < u.length;
                    r++) {
                    for (var t = u[r], n = !0, i = 1;
                        i < t.length;
                        i++) {
                        var l = t[i];
                        0 !== o[l] && (n = !1)
                    }
              ");
                WriteLiteral(@"      n && (u.splice(r--, 1), e = f(f.s = t[0]))
                }
                return e
            }
            var n = {
            }
                , o = {
                    1: 0
                }
                , u = [];
            function f(r) {
                if (n[r]) return n[r].exports;
                var t = n[r] = {
                    i: r, l: !1, exports: {
                    }
                }
                    ;
                return e[r].call(t.exports, t, t.exports, f), t.l = !0, t.exports
            }
            f.m = e, f.c = n, f.d = function (e, r, t) {
                f.o(e, r) || Object.defineProperty(e, r, {
                    enumerable: !0, get: t
                }
                )
            }
                , f.r = function (e) {
                    ""undefined"" != typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, {
                        value: ""Module""
                    }
                   ");
                WriteLiteral(@" ), Object.defineProperty(e, ""__esModule"", {
                        value: !0
                    }
                    )
                }
                , f.t = function (e, r) {
                    if (1 & r && (e = f(e)), 8 & r) return e;
                    if (4 & r && ""object"" == typeof e && e && e.__esModule) return e;
                    var t = Object.create(null);
                    if (f.r(t), Object.defineProperty(t, ""default"", {
                        enumerable: !0, value: e
                    }
                    ), 2 & r && ""string"" != typeof e) for (var n in e) f.d(t, n, function (r) {
                        return e[r]
                    }
                        .bind(null, n));
                    return t
                }
                , f.n = function (e) {
                    var r = e && e.__esModule ? function () {
                        return e.default
                    }
                        : function () {
                            return");
                WriteLiteral(@" e
                        }
                        ;
                    return f.d(r, ""a"", r), r
                }
                , f.o = function (e, r) {
                    return Object.prototype.hasOwnProperty.call(e, r)
                }
                , f.p = ""/"";
            var i = this[""webpackJsonpcreosafe-ui""] = this[""webpackJsonpcreosafe-ui""] || [], l = i.push.bind(i);
            i.push = r, i = i.slice();
            for (var a = 0;
                a < i.length;
                a++)r(i[a]);
            var c = l;
            t()
        }
            ([])</script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
