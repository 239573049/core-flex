namespace CoreFlex.Module;

public interface ICoreFlexModule
{
    Task ConfigureServicesAsync(CoreFlexServiceContext context);

    void ConfigureServices(CoreFlexServiceContext services);

    Task OnApplicationShutdownAsync(WebApplication app);

    void OnApplicationShutdown(WebApplication app);
}