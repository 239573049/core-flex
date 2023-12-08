using CoreFlex.Module;
using CoreFlex.Razor.JsInterop;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.Chat.Rcl;

[DependOns(typeof(CoreFlexRazorJsInteropModule))]
public class CoreFlexChatRclModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.AddMasaBlazor();

    }
}