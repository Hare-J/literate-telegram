#pragma checksum "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93b779d5192d33be64bbd5ecb56cfd864cc607f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserAccount_Details), @"mvc.1.0.view", @"/Views/UserAccount/Details.cshtml")]
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
#line 1 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\_ViewImports.cshtml"
using CanadaGames;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\_ViewImports.cshtml"
using CanadaGames.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93b779d5192d33be64bbd5ecb56cfd864cc607f5", @"/Views/UserAccount/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ca7df126862f209c84e5945aadfc51472a2f68b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_UserAccount_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CanadaGames.Models.User>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>User</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FavouriteIceCream));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayFor(model => model.FavouriteIceCream));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\UserAccount\Details.cshtml"
       Write(Html.DisplayFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CanadaGames.Models.User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591