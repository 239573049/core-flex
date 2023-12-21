using CoreFlex.Module;
using CoreFlex.Razor.JsInterop;
using Microsoft.Extensions.DependencyInjection;

namespace TokenGpt.Rcl;

[DependOns(typeof(CoreFlexRazorJsInteropModule))]
public class TokenGptRclModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.AddMasaBlazor();
    }
}