#pragma checksum "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05d06e982af6368ca8660a965fc062a4ebbb5a42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MascotaFeliz.App.Presentacion.Pages.RegisterPages.Pages_RegisterPages_DetailsVeterinario), @"mvc.1.0.razor-page", @"/Pages/RegisterPages/DetailsVeterinario.cshtml")]
namespace MascotaFeliz.App.Presentacion.Pages.RegisterPages
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
#line 1 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\_ViewImports.cshtml"
using MascotaFeliz.App.Presentacion;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d06e982af6368ca8660a965fc062a4ebbb5a42", @"/Pages/RegisterPages/DetailsVeterinario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d2d4d12cde42b399948991385062cf76f235456", @"/Pages/_ViewImports.cshtml")]
    public class Pages_RegisterPages_DetailsVeterinario : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml"
  
 Layout=null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>DETALLES DEL VETERINARIO</h1>\r\n<h2>Identificacion: ");
#nullable restore
#line 7 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml"
               Write(Model.Veterinario.Identificacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<div>\r\n    Nombre: ");
#nullable restore
#line 9 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml"
       Write(Model.Veterinario.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div>\r\n    Apellidos: ");
#nullable restore
#line 12 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml"
          Write(Model.Veterinario.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div>\r\n    Telefono: ");
#nullable restore
#line 15 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml"
         Write(Model.Veterinario.Telefono);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div>\r\n    Tarjeta Profesional:");
#nullable restore
#line 18 "C:\MascotaFeliz\MascotaFeliz.App\MascotaFeliz.App.Presentacion\Pages\RegisterPages\DetailsVeterinario.cshtml"
                   Write(Model.Veterinario.TarjetaProfesional);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "05d06e982af6368ca8660a965fc062a4ebbb5a425532", async() => {
                WriteLiteral("Lista de Veterinarios ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MascotaFeliz.App.Presentacion.Pages.DetailsVeterinarioModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MascotaFeliz.App.Presentacion.Pages.DetailsVeterinarioModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MascotaFeliz.App.Presentacion.Pages.DetailsVeterinarioModel>)PageContext?.ViewData;
        public MascotaFeliz.App.Presentacion.Pages.DetailsVeterinarioModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591