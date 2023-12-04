using AspNetCoreRateLimit;
using CoreFlex.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.RateLimiting;

public class CoreFlexRateLimitingModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.Configure<IpRateLimitOptions>
            (context.Configuration.GetSection("IpRateLimit"));
        
        context.Services.AddSingleton<IRateLimitConfiguration,
            RateLimitConfiguration>();
        
        context.Services.AddMemoryCache();
        context.Services.AddInMemoryRateLimiting();
    }

    public override void OnApplicationShutdown(WebApplication app)
    {
        app.UseIpRateLimiting();
    }
}