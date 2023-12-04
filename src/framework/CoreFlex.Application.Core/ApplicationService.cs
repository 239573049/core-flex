using Masa.BuildingBlocks.Authentication.Identity;

namespace CoreFlex.Application.Core;

/// <summary>
/// 应用服务基类
/// 提供获取服务的方法
/// 
/// </summary>
public abstract class ApplicationService 
{
    private readonly IServiceProvider _serviceProvider;

    protected ApplicationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    #region 获取服务

    protected T GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }

    protected T GetRequiredService<T>()
    {
        return _serviceProvider.GetRequiredService<T>();
    }

    protected T GetService<T>(Type type)
    {
        return (T)_serviceProvider.GetService(type);
    }

    protected T GetRequiredService<T>(Type type)
    {
        return (T)_serviceProvider.GetRequiredService(type);
    }

    protected object GetService(Type type)
    {
        return _serviceProvider.GetService(type);
    }

    protected object GetRequiredService(Type type)
    {
        return _serviceProvider.GetRequiredService(type);
    }

    protected IEnumerable<T> GetServices<T>()
    {
        return _serviceProvider.GetServices<T>();
    }

    protected IEnumerable<object> GetServices(Type type)
    {
        return _serviceProvider.GetServices(type);
    }

    protected IServiceProvider GetServiceProvider()
    {
        return _serviceProvider;
    }

    #endregion

    protected IUserContext GetUserContext()
    {
        return GetRequiredService<IUserContext>();
    }
}