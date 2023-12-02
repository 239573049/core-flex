namespace CoreFlex.Module;

public abstract class CoreFlexModel : ICoreFlexModel
{
    public virtual Task ConfigureServicesAsync(CoreFlexServiceContext context)
    {
        return Task.CompletedTask;
    }

    public virtual void ConfigureServices(CoreFlexServiceContext context)
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