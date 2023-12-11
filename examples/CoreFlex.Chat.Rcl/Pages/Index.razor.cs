namespace CoreFlex.Chat.Rcl.Pages;

public partial class Index
{
    private List<ChatMenuItem> chatMenuItems = new();

    private const string ChatMenuItemKey = "ChatMenuItemKey";

    protected override async Task OnInitializedAsync()
    {
        if (await LocalStorageJsInterop.ContainKeyAsync(ChatMenuItemKey))
        {
            chatMenuItems = await LocalStorageJsInterop.GetLocalStorageAsync<List<ChatMenuItem>>(ChatMenuItemKey);
        }
        else
        {
            chatMenuItems.Add(new ChatMenuItem(Guid.NewGuid(), "智能AI助手", "一个AI智能助手", "gpt-3.5-turbo-1106", string.Empty, 2000));
        }
    }

    private string GetLastUpdate(DateTime? lastUpdate)
    {
        return lastUpdate.HasValue ? lastUpdate.Value.ToString("HH:mm") : DateTime.Now.ToString("HH:mm");
    }
}
