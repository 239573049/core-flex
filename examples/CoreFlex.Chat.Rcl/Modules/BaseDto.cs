namespace CoreFlex.Chat.Rcl.Modules;

public abstract class BaseDto<TKey>
{
    public TKey Id { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
}