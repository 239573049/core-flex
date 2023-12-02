namespace CoreFlex.Module;

/// <summary>
/// 增加模块依赖关系
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DependOnsAttribute : Attribute
{
    public Type[] Type { get; }

    public DependOnsAttribute(params Type[] type)
    {
        Type = type;
    }
}