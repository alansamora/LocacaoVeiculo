#pragma checksum "C:\Users\137105\LocacaoVeiculo\LocacaoVeiculoWeb\LocacaoVeiculoWeb\Views\Home\Reservation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "761d80f9206c06e68fa4be01b7f822c789d06034"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Reservation), @"mvc.1.0.view", @"/Views/Home/Reservation.cshtml")]
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
#line 1 "C:\Users\137105\LocacaoVeiculo\LocacaoVeiculoWeb\LocacaoVeiculoWeb\Views\_ViewImports.cshtml"
using LocacaoVeiculoWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\137105\LocacaoVeiculo\LocacaoVeiculoWeb\LocacaoVeiculoWeb\Views\_ViewImports.cshtml"
using LocacaoVeiculoWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"761d80f9206c06e68fa4be01b7f822c789d06034", @"/Views/Home/Reservation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d105cb205fda66e7802722c1a9eb30f78ac4344f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Reservation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\137105\LocacaoVeiculo\LocacaoVeiculoWeb\LocacaoVeiculoWeb\Views\Home\Reservation.cshtml"
  
    ViewData["Title"] = "Reserva";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""text-center"">
        <h1 class=""display-4"">Reserva</h1>
        <h3 class=""text-blue"">Luxo</h3>
        <p>Selecione o período para verificar a disponibilidade dos veículos.</p>

        <div class=""row"">
            <div class=""col-md-5 mb-2"">
                <div class=""input-group"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Início</span>
                    </div>
                    <input type=""text"" class=""form-control"" required>
                </div>
            </div>
            <div class=""col-md-5 mb-2"">
                <div class=""input-group"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Fim</span>
                    </div>
                    <input type=""text"" class=""form-control"" required>
                </div>
            </div>
            <div class=""col-md-2 mb-2"">
                <a class=""btn btn-primary"" role=""but");
            WriteLiteral(@"ton"" style=""color:#ffffff !important;"">Buscar</a>
            </div>
        </div>

        <div class=""row"" style=""padding-top:25px;"">
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Marca</th>
                        <th scope=""col"">Modelo</th>
                        <th scope=""col"">Placa</th>
                        <th scope=""col"">Ano</th>
                        <th scope=""col"">Combustivel</th>
                        <th scope=""col"">Valor Hora</th>
                        <th scope=""col"">Total</th>
                        <th scope=""col"">Ação</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope=""row"">1</th>
                        <td>Chevrolet</td>
                        <td>Onix 1.0</td>
                        <td>HRT-2932</td>
                        <td>2");
            WriteLiteral(@"020</td>
                        <td>Gasolina</td>
                        <td>R$ 13,00</td>
                        <td>R$ 856,30</td>
                        <td><a class=""btn btn-primary"" role=""button"" style=""color:#ffffff !important;"">Selecionar</a></td>
                    </tr>
                    <tr>
                        <th scope=""row"">2</th>
                        <td>Fiat</td>
                        <td>Argo 1.0</td>
                        <td>FTP-1037</td>
                        <td>2021</td>
                        <td>Gasolina</td>
                        <td>R$ 7,00</td>
                        <td>R$ 436,00</td>
                        <td><a class=""btn btn-primary"" role=""button"" style=""color:#ffffff !important;"">Selecionar</a></td>
                    </tr>
                    <tr>
                        <th scope=""row"">3</th>
                        <td>Volkswagen</td>
                        <td>Polo 1.0</td>
                        <td>XUS-5021</td>
          ");
            WriteLiteral(@"              <td>2021</td>
                        <td>Gasolina</td>
                        <td>R$ 17,00</td>
                        <td>R$ 946,87</td>
                        <td><a class=""btn btn-primary"" role=""button"" style=""color:#ffffff !important;"">Selecionar</a></td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>

");
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
