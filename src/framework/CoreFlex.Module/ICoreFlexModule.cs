namespace CoreFlex.Module;

public interface ICoreFlexModule
{
    Task ConfigureServicesAsync(CoreFlexServiceContext context);

    void ConfigureServices(CoreFlexServiceContext context);

    Task OnApplicationShutdownAsync(CoreFlexBuilder builder);

    void OnApplicationShutdown(CoreFlexBuilder builder);
}