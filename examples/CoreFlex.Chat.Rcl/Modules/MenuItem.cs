namespace CoreFlex.Chat.Rcl.Modules;

public class MenuItem
{
    /// <summary>
    /// 显示图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 跳转地址
    /// </summary>
    public string Href { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 点击事件
    /// </summary>
    public Action OnClick { get; set; }
}