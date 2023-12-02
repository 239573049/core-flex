namespace CoreFlex.Module;

public interface ICoreFlexModel
{
    Task ConfigureServicesAsync(IServiceCollection services);

    void ConfigureServices(IServiceCollection services);

    Task OnApplicationShutdownAsync(IApplicationBuilder app);

    void OnApplicationShutdown(IApplicationBuilder app);
}