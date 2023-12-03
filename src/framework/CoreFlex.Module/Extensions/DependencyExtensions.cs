namespace CoreFlex.Module.Extensions;

public static class DependencyExtensions
{
    /// <summary>
    /// 是否支持注入
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsAssignableModule(this Type type)
    {
        var disabledInjectAttribute = type.GetCustomAttribute<DisabledInjectAttribute>();
        
        if (disabledInjectAttribute?.Disabled == true)
        {
            return false;
        }

        if (type.Attributes.HasFlag(TypeAttributes.Abstract) || type.Attributes.HasFlag(TypeAttributes.Interface))
        {
            return false;
        }

        if (typeof(ISingletonDependency).IsAssignableFrom(type) ||
                           typeof(IScopedDependency).IsAssignableFrom(type) ||
                           typeof(ITransientDependency).IsAssignableFrom(type))
        {
            return true;
        }

        return false;
    }
}