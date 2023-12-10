using CoreFlex.Module;

namespace CoreFlex.Event.Handlers;

public interface ILoadEventHandler<in TEto> : IScopedDependency where TEto : class
{
    Task HandleAsync(TEto eto);

    Task ExceptionHandling(Exception exception,TEto eto);
}