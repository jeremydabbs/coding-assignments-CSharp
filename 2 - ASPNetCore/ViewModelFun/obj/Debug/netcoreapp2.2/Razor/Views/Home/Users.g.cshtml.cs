#pragma checksum "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\Home\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4a0e98bf85079c2c31447ba9dcf43ad1842ea74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Users), @"mvc.1.0.view", @"/Views/Home/Users.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Users.cshtml", typeof(AspNetCore.Views_Home_Users))]
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
#line 1 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\_ViewImports.cshtml"
using ViewModelFun;

#line default
#line hidden
#line 2 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\_ViewImports.cshtml"
using ViewModelFun.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4a0e98bf85079c2c31447ba9dcf43ad1842ea74", @"/Views/Home/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7312364e6c23e4cb7805f9e5f986831fce186000", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\Home\Users.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(64, 103, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <h2>Here are some Users</h2>\r\n");
            EndContext();
#line 10 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\Home\Users.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
            BeginContext(242, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(254, 14, false);
#line 12 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\Home\Users.cshtml"
      Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(268, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(270, 13, false);
#line 12 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\Home\Users.cshtml"
                      Write(user.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(283, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 13 "C:\Users\jndab\Documents\CodingDojo\CSharp\ASPNetCore\ViewModelFun\Views\Home\Users.cshtml"
    }

#line default
#line hidden
            BeginContext(296, 6, true);
            WriteLiteral("</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
