namespace CoreFlex.Module;

public abstract class CoreFlexModel : ICoreFlexModel
{
    public virtual Task ConfigureServicesAsync(IServiceCollection services)
    {
        return Task.CompletedTask;
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {
    }

    public virtual Task OnApplicationShutdownAsync(IApplicationBuilder app)
    {
        return Task.CompletedTask;
    }

    public virtual void OnApplicationShutdown(IApplicationBuilder app)
    {
    }
    
}