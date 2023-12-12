/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Rcl.Pages.Users;

public partial class ChatMessage : IAsyncDisposable
{
    private CurrentUserInfo userInfo;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var token = await LocalStorageJsInterop.GetLocalStorageAsync(Constant.Rcl.Token);

            if (!JwtHelper.ValidateToken(token))
            {
                NavigationManager.NavigateTo("/users/login");
            }

            userInfo = JwtHelper.GetClaimValue<CurrentUserInfo>(token, Constant.Rcl.UserInfo);

            await UserManagerService.AddUserInfoAsync(userInfo);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await UserManagerService.RemoveUserInfoAsync(userInfo);
    }
}