#pragma checksum "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5ad9a087d1bf1acd5d38017286d1d9088ee8126"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_CastDetails), @"mvc.1.0.view", @"/Views/Movies/CastDetails.cshtml")]
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
#line 1 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5ad9a087d1bf1acd5d38017286d1d9088ee8126", @"/Views/Movies/CastDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_CastDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.Response.CastDetailsResponseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <div>\r\n\r\n                <p>");
#nullable restore
#line 8 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"
              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 244, "\"", 268, 1);
#nullable restore
#line 10 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"
WriteAttributeValue("", 250, Model.ProfilePath, 250, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                         class=\"rounded float-start\"");
            BeginWriteAttribute("alt", "\r\n                         alt=\"", 323, "\"", 366, 1);
#nullable restore
#line 12 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"
WriteAttributeValue("", 355, Model.Name, 355, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </p>\r\n                <h5>Movie List</h5>\r\n");
#nullable restore
#line 15 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"
                 foreach (var movie in Model.Movie)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 556, "\"", 578, 1);
#nullable restore
#line 18 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"
WriteAttributeValue("", 562, movie.PosterUrl, 562, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                             class=\"rounded float-start\"");
            BeginWriteAttribute("alt", "\r\n                             alt=\"", 637, "\"", 689, 1);
#nullable restore
#line 20 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"
WriteAttributeValue("", 673, movie.PosterUrl, 673, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </p>\r\n");
#nullable restore
#line 22 "C:\Users\XuejianZhou\Desktop\Project\MovieShop\MovieShop.MVC\Views\Movies\CastDetails.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


            </div>
        </div>
        <div class=""col-6"">
            2 of 3 (wider)
        </div>
        <div class=""col"">
            3 of 3
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            1 of 3
        </div>
        <div class=""col-5"">
            2 of 3 (wider)
        </div>
        <div class=""col"">
            3 of 3
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.Response.CastDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591