namespace CoreFlex.Chat.Rcl.Pages;

public partial class Index
{
    private List<ChatMenuItem> chatMenuItems = new();

    private ChatMenuItem selectMenuItem;

    private const string ChatMenuItemKey = "ChatMenuItemKey";

    protected override async Task OnInitializedAsync()
    {
        if (await LocalStorageJsInterop.ContainKeyAsync(ChatMenuItemKey))
        {
            chatMenuItems = await LocalStorageJsInterop.GetLocalStorageAsync<List<ChatMenuItem>>(ChatMenuItemKey);
        }
        else
        {
            var menu = new ChatMenuItem(Guid.NewGuid(), "1智能AI助手", "一个AI智能助手", "gpt-3.5-turbo-1106", string.Empty);
            menu.OnClick += async () => await OnSelect(menu);
            await OnSelect(menu);
            chatMenuItems.Add(menu);


            var menu1 = new ChatMenuItem(Guid.NewGuid(), "2智能AI助手", "一个AI智能助手", "gpt-3.5-turbo-1106", string.Empty);
            menu1.OnClick += async () => await OnSelect(menu1);
            await OnSelect(menu1);
            chatMenuItems.Add(menu1);
        }
    }

    private async Task OnSelect(ChatMenuItem item)
    {
        selectMenuItem = item;
        await InvokeAsync(StateHasChanged);
    }

    private string GetLastUpdate(DateTime? lastUpdate)
    {
        return lastUpdate.HasValue ? lastUpdate.Value.ToString("HH:mm") : DateTime.Now.ToString("HH:mm");
    }
}
