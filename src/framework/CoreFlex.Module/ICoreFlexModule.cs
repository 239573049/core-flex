namespace CoreFlex.Module;

public interface ICoreFlexModule
{
    Task ConfigureServicesAsync(CoreFlexServiceContext context);

    void ConfigureServices(CoreFlexServiceContext services);

    Task OnApplicationShutdownAsync(IApplicationBuilder app);

    void OnApplicationShutdown(IApplicationBuilder app);
}