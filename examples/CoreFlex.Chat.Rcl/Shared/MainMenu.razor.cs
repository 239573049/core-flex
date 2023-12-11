
namespace CoreFlex.Chat.Rcl;

public partial class MainMenu
{
    private List<MenuItem> _menuItems = new(1);

    private MenuItem _selectItem;

    protected override void OnInitialized()
    {
        var menu = new MenuItem()
        {
            Icon = "md:chat",
            Href = "/",
            Name = "聊天"
        };

        menu.OnClick = () => Goto(menu);

        _selectItem = menu;

        _menuItems.Add(menu);
    }

    private void Goto(MenuItem menuItem)
    {
        _selectItem = menuItem;
        NavigationManager.NavigateTo(menuItem.Href);
    }
}