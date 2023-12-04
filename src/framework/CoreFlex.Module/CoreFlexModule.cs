namespace CoreFlex.Module;

public abstract class CoreFlexModule : ICoreFlexModule
{
    private IServiceCollection _service { get; set; }
    
    public virtual Task ConfigureServicesAsync(CoreFlexServiceContext context)
    {
        _service = context.Services;
        return Task.CompletedTask;
    }

    public virtual void ConfigureServices(CoreFlexServiceContext context)
    {
    }
    
    public virtual Task OnApplicationShutdownAsync(WebApplication app)
    {
        return Task.CompletedTask;
    }

    public virtual void OnApplicationShutdown(WebApplication app)
    {
    }
    
    protected void Configure<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        _service.Configure(configureOptions);

    protected void Configure<TOptions>(string name, Action<TOptions> configureOptions) where TOptions : class =>
        _service.Configure(name, configureOptions);
}