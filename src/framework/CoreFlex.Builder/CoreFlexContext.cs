using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.Builder;

/// <summary>
/// CoreFlex上下文
/// </summary>
public class CoreFlexContext
{
    private static IServiceCollection _service;

    private static IServiceCollection Services
    {
        get
        {
            if (_service == null)
            {
                throw new Exception("并没未构建Context！");
            }

            return _service;
        }
        set => _service = value;
    }

    private static IServiceProvider _provider;

    private static IServiceProvider ServiceProvider
    {
        get
        {
            if (_provider == null)
            {
                throw new Exception("并没Builder Context");
            }

            return _provider;
        }
        set => _provider = value;
    }

    /// <summary>
    /// 创建服务
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IServiceCollection CreateContext(Action<IServiceCollection> options)
    {
        Services = new ServiceCollection();
        options(Services);
        return Services;
    }

    /// <summary>
    /// 构建Context
    /// </summary>
    /// <returns></returns>
    public static IServiceProvider Builder()
    {
        ServiceProvider = Services.BuildServiceProvider();
        return ServiceProvider;
    }

    public static T GetService<T>()
        => ServiceProvider.GetService<T>();

    public static object GetService(Type type)
        => ServiceProvider.GetService(type);

    public static T GetRequiredService<T>()
        => ServiceProvider.GetRequiredService<T>();

    public static object GetRequiredService(Type type)
        => ServiceProvider.GetRequiredService(type);

    public static IEnumerable<T> GetServices<T>()
        => ServiceProvider.GetServices<T>();
    
    public static IEnumerable<object> GetServices(Type type)
        => ServiceProvider.GetServices(type);
}