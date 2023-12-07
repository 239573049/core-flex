﻿namespace CoreFlex.Module;

public abstract class CoreFlexModule : ICoreFlexModule
{
    private IServiceCollection _service { get; set; }

    public virtual Task ConfigureServicesAsync(CoreFlexServiceContext context)
    {
        _service = context.Services;
        return Task.CompletedTask;
    }

    public virtual void ConfigureServices(CoreFlexServiceContext services)
    {
    }

    public virtual async Task OnApplicationShutdownAsync(CoreFlexBuilder app)
    {
        await Task.CompletedTask;
    }

    public virtual void OnApplicationShutdown(CoreFlexBuilder app)
    {
    }

#if NET8_0
    
    protected void Configure<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        _service.Configure(configureOptions);

    protected void Configure<TOptions>(string name, Action<TOptions> configureOptions) where TOptions : class =>
        _service.Configure(name, configureOptions);
    
#endif
}