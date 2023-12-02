namespace CoreFlex.Module;

/// <summary>
/// 指定注入实现服务，将不会根据接口注入
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExposeServicesAttribute : Attribute
{
    public readonly Type? Type;

    public ExposeServicesAttribute(Type? type)
    {
        Type = type;
    }
}