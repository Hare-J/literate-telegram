#pragma checksum "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec0162ee8b878610e108522299efa5b15b5bb39d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Athletes_Details), @"mvc.1.0.view", @"/Views/Athletes/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec0162ee8b878610e108522299efa5b15b5bb39d", @"/Views/Athletes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ca7df126862f209c84e5945aadfc51472a2f68b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Athletes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CanadaGames.Models.Athlete>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
  
    ViewData["Title"] = "Athlete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Athlete Details: ");
#nullable restore
#line 7 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div>\r\n    <hr />\r\n");
#nullable restore
#line 11 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
      
        if (Model.AthletePhoto?.Content != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div>\r\n");
#nullable restore
#line 15 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                string imageBase64 = Convert.ToBase64String(Model.AthletePhoto.Content);
                string imageSrc = string.Format("data:" + Model.AthletePhoto.MimeType + ";base64,{0}", imageBase64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img");
            BeginWriteAttribute("src", " src=\"", 464, "\"", 479, 1);
#nullable restore
#line 17 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue("", 470, imageSrc, 470, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 480, "\"", 520, 4);
            WriteAttributeValue("", 486, "Profile", 486, 7, true);
            WriteAttributeValue(" ", 493, "Picture", 494, 8, true);
            WriteAttributeValue(" ", 501, "of", 502, 3, true);
#nullable restore
#line 17 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue(" ", 504, Model.FullName, 505, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 521, "\"", 563, 4);
            WriteAttributeValue("", 529, "Profile", 529, 7, true);
            WriteAttributeValue(" ", 536, "Picture", 537, 8, true);
            WriteAttributeValue(" ", 544, "of", 545, 3, true);
#nullable restore
#line 17 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue(" ", 547, Model.FullName, 548, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid rounded\" />\r\n            ");
            WriteLiteral("</div><hr />\r\n");
#nullable restore
#line 19 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<dl class=\"row\">\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 23 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 26 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 29 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 32 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.MiddleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 35 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 38 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 41 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.AthleteCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 44 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.ACode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 47 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 50 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 53 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 56 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 59 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 62 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 65 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.YearsInSport));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 68 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.YearsInSport));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 71 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Affiliation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 74 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Affiliation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 77 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Goals));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 80 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Goals));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 83 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.MediaInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 86 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.MediaInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 89 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Contingent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 92 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Contingent.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 95 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Hometown));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 98 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Hometown.HometownContingent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 101 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Sport));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 104 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Sport.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 107 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.AthleteSports));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 110 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
          
            int theCount = Model.AthleteSports.Count;
            if (theCount > 0)
            {
                string first = Model.AthleteSports.FirstOrDefault().Sport.Name;
                if (theCount > 1)
                {
                    string theList = first;
                    var c = Model.AthleteSports.ToList();
                    for (int i = 1; i < theCount; i++)
                    {
                        theList += ", " + c[i].Sport.Name;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a tabindex=\"0\"");
            BeginWriteAttribute("class", " class=\"", 3906, "\"", 3914, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" data-toggle=\"popover\"\r\n                       data-trigger=\"focus\" title=\"Alternate Sports\" data-placement=\"bottom\"\r\n                       data-content=\"");
#nullable restore
#line 125 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                                Write(theList);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        ");
#nullable restore
#line 126 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                   Write(first);

#line default
#line hidden
#nullable disable
            WriteLiteral("... <span class=\"badge badge-info\">\r\n                            ");
#nullable restore
#line 127 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                       Write(theCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </a>\r\n");
#nullable restore
#line 130 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
               Write(first);

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                          
                }
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 139 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 142 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Gender.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 145 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Coach));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 148 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Coach.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 151 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.AthleteDocuments));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n");
#nullable restore
#line 154 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
          
            int fileCount = Model.AthleteDocuments.Count;
            if (fileCount > 0)
            {
                var firstFile = Model.AthleteDocuments.FirstOrDefault(); ;
                if (fileCount > 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("class", " class=\"", 5172, "\"", 5180, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" data-toggle=\"collapse\"");
            BeginWriteAttribute("href", " href=\"", 5218, "\"", 5249, 2);
            WriteAttributeValue("", 5225, "#collapseDocs", 5225, 13, true);
#nullable restore
#line 161 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue("", 5238, Model.ID, 5238, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-expanded=\"false\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 5272, "\"", 5311, 2);
            WriteAttributeValue("", 5288, "collapseDocs", 5288, 12, true);
#nullable restore
#line 161 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue("", 5300, Model.ID, 5300, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span class=\"badge badge-info\">");
#nullable restore
#line 162 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                                                  Write(fileCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> Documents...\r\n                    </a>\r\n                    <div class=\"collapse\"");
            BeginWriteAttribute("id", " id=\"", 5469, "\"", 5497, 2);
            WriteAttributeValue("", 5474, "collapseDocs", 5474, 12, true);
#nullable restore
#line 164 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue("", 5486, Model.ID, 5486, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 165 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                          
                            foreach (var d in Model.AthleteDocuments)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec0162ee8b878610e108522299efa5b15b5bb39d25728", async() => {
#nullable restore
#line 168 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                                                                         Write(d.FileName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 168 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                                                           WriteLiteral(d.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <br />\r\n");
#nullable restore
#line 169 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n");
#nullable restore
#line 172 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec0162ee8b878610e108522299efa5b15b5bb39d28886", async() => {
#nullable restore
#line 175 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                                                                     Write(firstFile.FileName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 175 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                                               WriteLiteral(firstFile.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 176 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                }
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dd>\r\n</dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec0162ee8b878610e108522299efa5b15b5bb39d31712", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 183 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
                           WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    <a");
            BeginWriteAttribute("href", " href=\'", 6124, "\'", 6153, 1);
#nullable restore
#line 184 "C:\Users\jahar\OneDrive\Niagara College\T3 Fall 2021\PROG1322 (Design Patterns)\1322A4_Hare\CanadaGames\Views\Athletes\Details.cshtml"
WriteAttributeValue("", 6131, ViewData["returnURL"], 6131, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Back to Athlete List</a>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            $(\'[data-toggle=\"popover\"]\').popover();\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CanadaGames.Models.Athlete> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
