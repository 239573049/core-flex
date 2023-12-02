using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.EntityFrameworkCore;

public class CoreEntityFrameworkCoreModel : CoreFlexModel
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.AddScoped(typeof(ICoreFlexRepository<>), typeof(CoreFlexRepository<,>));
    }
}