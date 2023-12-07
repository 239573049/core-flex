namespace CoreFlex.Module;

public class CoreFlexServiceContext
{
    public IServiceCollection Services { get; init; }
    
    public IConfiguration Configuration { get; init; }
    
    public CoreFlexServiceContext(IServiceCollection services, IConfiguration configuration)
    {
        Services = services;
        Configuration = configuration;
    }
}