/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Rcl.Modules;

public class MenuItem
{
    /// <summary>
    /// 显示图标
    /// </summary>
    public string Icon { get; set; }

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