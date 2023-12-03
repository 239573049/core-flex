using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.EntityFrameworkCore;

public class CoreEntityFrameworkCoreModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.AddScoped(typeof(ICoreFlexRepository<>), typeof(CoreFlexRepository<,>));
    }
}