using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CoreFlex.Module.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 默认运行顺序
    /// </summary>
    private static int _defaultOrder = 1;

    public static void SetDefaultOrder(int order)
    {
        _defaultOrder = order;
    }

    private static readonly Dictionary<int, ICoreFlexModule> CoreFlexModels;

    static ServiceCollectionExtensions()
    {
        CoreFlexModels = new Dictionary<int, ICoreFlexModule>();
    }

#if NET8_0
    /// <summary>
    /// 添加CoreFlex并且自动注入
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="autoInject">是否自动注入服务</param>
    /// <param name="options">Config Options</param>
    /// <typeparam name="TCoreFlex"></typeparam>
    public static async Task AddCoreFlexAutoInjectAsync<TCoreFlex>(this IHostApplicationBuilder builder,
        bool autoInject = true)
        where TCoreFlex : ICoreFlexModule
    {
        await builder.Services.AddCoreFlexAsync<TCoreFlex>(builder.Configuration);

        if (autoInject)
            builder.Services.AddAutoInject();
    }
#endif


#if NET7_0
    /// <summary>
    /// 添加CoreFlex并且自动注入
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="autoInject">是否自动注入服务</param>
    /// <param name="options">Config Options</param>
    /// <typeparam name="TCoreFlex"></typeparam>
    public static async Task AddCoreFlexAutoInjectAsync<TCoreFlex>(this HostApplicationBuilder builder,
        bool autoInject = true)
        where TCoreFlex : ICoreFlexModule
    {
        await builder.Services.AddCoreFlexAsync<TCoreFlex>(builder.Configuration);

        if (autoInject)
            builder.Services.AddAutoInject();
    }
#endif


#if NET6_0
    /// <summary>
    /// 添加CoreFlex并且自动注入
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="autoInject">是否自动注入服务</param>
    /// <typeparam name="TCoreFlex"></typeparam>
    public static async Task AddCoreFlexAutoInjectAsync<TCoreFlex>(this WebApplicationBuilder builder,
        bool autoInject = true)
        where TCoreFlex : ICoreFlexModule
    {
        await builder.Services.AddCoreFlexAsync<TCoreFlex>(builder.Configuration);

        if (autoInject)
            builder.Services.AddAutoInject();
    }
#endif


    /// <summary>
    /// 添加CoreFlex并且自动注入
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="autoInject">是否自动注入服务</param>
    /// <param name="options">Config Options</param>
    /// <typeparam name="TCoreFlex"></typeparam>
    public static async Task AddCoreFlexAutoInjectAsync<TCoreFlex>(this IServiceCollection builder,
        IConfiguration options,
        bool autoInject = true)
        where TCoreFlex : ICoreFlexModule
    {
        await builder.AddCoreFlexAsync<TCoreFlex>(options);

        if (autoInject)
            builder.AddAutoInject();
    }


    /// <summary>
    /// 添加CoreFlex
    /// </summary>
    /// <param name="services"></param>
    /// <param name="options">Config Options</param>
    public static async Task AddCoreFlexAsync<TCoreFlex>(this IServiceCollection services, IConfiguration configuration)
        where TCoreFlex : ICoreFlexModule
    {
        var type = typeof(TCoreFlex);

        GetModuleType(type);

        services.AddSingleton(configuration);

        var coreFlexServiceContext =
            new CoreFlexServiceContext(services, configuration)
            {
                Services = services,
                Configuration = configuration
            };

        foreach (var t in CoreFlexModels.OrderBy(x => x.Key).Select(x => x.Value).Distinct())
        {
            t.ConfigureServices(coreFlexServiceContext);
            await t.ConfigureServicesAsync(coreFlexServiceContext).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// 将依赖的模块自动注入到服务当中
    /// 这个方法只会注入继承响应的接口的实现类，根据集成的接口注入不同的生命周期
    /// </summary>
    /// <param name="services"></param>
    public static void AddAutoInject(this IServiceCollection services)
    {
        // 加载所有需要注入的程序集（只有引用的模块）
        var assemblies = CoreFlexModels.Select(x => x.Value.GetType().Assembly)
            .SelectMany(x => x.GetTypes()).Where(x => x.IsAssignableModule()).ToList();

        // 根据继承的接口注入相对应的生命周期
        foreach (var t in assemblies)
        {
            var interfaces = t.GetDependencyType();

            if (interfaces != null)
            {
                if (t.IsAssignableFrom<ITransientDependency>())
                {
                    services.AddTransient(interfaces, t);
                }
                else if (t.IsAssignableFrom<IScopedDependency>())
                {
                    services.AddScoped(interfaces, t);
                }
                else if (t.IsAssignableFrom<ISingletonDependency>())
                {
                    services.AddSingleton(interfaces, t);
                }
            }
            else
            {
                if (t.IsAssignableFrom<ITransientDependency>())
                {
                    services.AddTransient(t);
                }
                else if (t.IsAssignableFrom<IScopedDependency>())
                {
                    services.AddScoped(t);
                }
                else if (t.IsAssignableFrom<ISingletonDependency>())
                {
                    services.AddSingleton(t);
                }
            }
        }
    }

    /// <summary>
    /// 初始化Application
    /// </summary>
    /// <param name="app"></param>
    public static async Task UseCoreFlexAsync(this IServiceProvider app)
    {
        var modules = CoreFlexModels?.OrderBy(x => x.Key).Select(x => x.Value);

        if (modules == null)
            throw new ArgumentNullException(nameof(modules));

        var coreFlexBuilder = new CoreFlexBuilder(app);

        foreach (var module in modules)
        {
            module.OnApplicationShutdown(coreFlexBuilder);
            await module.OnApplicationShutdownAsync(coreFlexBuilder);
        }
    }

    /// <summary>
    /// 加载模块，扫描模块依赖的其他的模块
    /// </summary>
    /// <param name="type"></param>
    private static void GetModuleType(Type type)
    {
        if (!type.IsAssignableFrom<ICoreFlexModule>())
        {
            return;
        }

        // 通过放射创建一个对象并且回调方法
        var typeInstance = type.Assembly.CreateInstance(type.FullName, true) as ICoreFlexModule;

        // 如果对象为空则返回
        if (typeInstance == null)
        {
            return;
        }

        CoreFlexModels.Add(GetRunOrder(type), typeInstance);

        foreach (var t in type.GetCustomAttributes().OfType<DependOnsAttribute>()
                     .SelectMany(x => x.Type).Where(x => x.IsAssignableFrom<ICoreFlexModule>()))
        {
            // 判断t是否继承了ICoreFlexModel
            if (!t.IsAssignableFrom<ICoreFlexModule>())
            {
                continue;
            }

            // 递归调用
            GetModuleType(t);
        }
    }

    /// <summary>
    /// 获取注入方法相对应的需要注入的标记
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static Type? GetDependencyType(this Type type)
    {
        var exposeServices = type.GetCustomAttribute<ExposeServicesAttribute>();
        if (exposeServices == null)
        {
            return type.GetInterfaces().Where(x => x.Name.EndsWith(type.Name))?.FirstOrDefault();
        }

        return type.GetInterfaces().Where(x => x == exposeServices.Type)?.FirstOrDefault();
    }

    /// <summary>
    /// 是否支持注入
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static bool IsAssignableModule(this Type type)
    {
        if (type.Attributes.HasFlag(TypeAttributes.Abstract) || type.Attributes.HasFlag(TypeAttributes.Interface))
        {
            return false;
        }

        var disabledInjectAttribute = type.GetCustomAttribute<DisabledInjectAttribute>();

        if (disabledInjectAttribute?.Disabled == true)
        {
            return false;
        }

        return typeof(ISingletonDependency).IsAssignableFrom(type) ||
               typeof(IScopedDependency).IsAssignableFrom(type) ||
               typeof(ITransientDependency).IsAssignableFrom(type);
    }

    /// <summary>
    /// 判断是否继承接口
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static bool IsAssignableFrom<T>(this Type t) =>
        typeof(T).IsAssignableFrom(t);

    /// <summary>
    /// 回去模块运行顺序
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static int GetRunOrder(MemberInfo type)
    {
        var runOrder = type.GetCustomAttribute<RunOrderAttribute>();

        return runOrder?.Order ?? _defaultOrder++;
    }
}