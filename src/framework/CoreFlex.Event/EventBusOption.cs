namespace CoreFlex.Event;

/// <summary>
/// 本地事件配置
/// </summary>
public class EventBusOption
{
    /// <summary>
    /// 设置EventManager的默认管道容量
    /// </summary>
    public int Capacity { get; set; } = 100000;

    /// <summary>
    /// 异常处理
    /// </summary>
    public Func<Exception,object,bool>? ExceptionHandling { get; set; }
}