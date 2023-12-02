namespace CoreFlex.Module;

public class CoreFlexServiceContext
{
    public IServiceCollection Services { get; init; }
    
    public IConfiguration Configuration { get; init; }
    
    public IHostEnvironment Environment { get; init; }
    
    public CoreFlexServiceContext(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        Services = services;
        Configuration = configuration;
        Environment = environment;
    }
}