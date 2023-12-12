/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Rcl.Pages;

public partial class Index
{
    private List<ChatMenuItem> chatMenuItems = new();

    private ChatMenuItem? selectMenuItem;

    protected override async Task OnInitializedAsync()
    {
        await LoadUsersAsync();

        await UserManagerService.Subscription(UserInfoAsync);

    }

    private async Task LoadUsersAsync()
    {
        var userInfos = await UserManagerService.GetUserInfoAsync();

        foreach (var info in userInfos)
        {
            var item = new ChatMenuItem(info.Id, info.Name, "", "");
            item.OnClick = () => OnSelect(item);
            chatMenuItems.Add(item);
        }
        await InvokeAsync(StateHasChanged);

    }

    private async void UserInfoAsync(UserStatus status, CurrentUserInfo info)
    {
        if (status == UserStatus.Offline)
        {
            chatMenuItems.Where(x => x.Id == info.Id).ForEach(x =>
            {
                x.Status = status;
            });

        }
        else if (chatMenuItems.Any(x => x.Id == info.Id))// 如果已经存在列表则修改状态
        {
            chatMenuItems.Where(x => x.Id == info.Id).ForEach(x =>
            {
                x.Status = status;
            });
        }
        else
        {
            var item = new ChatMenuItem(info.Id, info.Name, "", "");
            item.OnClick = () => OnSelect(item);
            chatMenuItems.Add(item);
        }

        await InvokeAsync(StateHasChanged);
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
