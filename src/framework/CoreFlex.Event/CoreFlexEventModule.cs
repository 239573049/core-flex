using CoreFlex.Event.Events;
using CoreFlex.Module;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.Event;

public class CoreFlexEventModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext services)
    {
        services.Services.AddSingleton(typeof(EventManager<>));
        services.Services.AddSingleton(typeof(ILoadEventBus<>), typeof(LoadEventBus<>));
    }
}