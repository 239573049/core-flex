namespace CoreFlex.Module;

public class CoreFlexBuilder
{
    public IServiceProvider Services { get; init; }

    public CoreFlexBuilder(IServiceProvider services)
    {
        Services = services;
    }
}