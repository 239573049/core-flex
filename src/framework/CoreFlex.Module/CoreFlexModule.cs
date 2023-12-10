namespace CoreFlex.Module;

public abstract class CoreFlexModule : ICoreFlexModule
{
    private IServiceCollection _service { get; set; }

    public virtual Task ConfigureServicesAsync(CoreFlexServiceContext context)
    {
        return Task.CompletedTask;
    }

    public virtual void ConfigureServices(CoreFlexServiceContext context)
    {
    }

    public virtual async Task OnApplicationShutdownAsync(CoreFlexBuilder app)
    {
        await Task.CompletedTask;
    }

    public virtual void OnApplicationShutdown(CoreFlexBuilder app)
    {
    }

    protected void Configure<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        _service.Configure(configureOptions);

    protected void Configure<TOptions>(string name, Action<TOptions> configureOptions) where TOptions : class =>
        _service.Configure(name, configureOptions);
}