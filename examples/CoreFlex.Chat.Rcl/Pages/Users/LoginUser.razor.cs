/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Rcl.Pages.Users;

public partial class LoginUser
{
    /// <summary>
    /// 绑定昵称
    /// </summary>
    public string Name { get; set; }

    private async Task GoTokenAsync()
    {
        var token = await UserService.GetTokenAsync(Name);

        await LocalStorageJsInterop.SetLocalStorageAsync(Constant.Rcl.Token, token);
        NavigationManager.NavigateTo("/users/chat");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var token = await LocalStorageJsInterop.GetLocalStorageAsync(Constant.Rcl.Token);

            if (JwtHelper.ValidateToken(token))
            {
                NavigationManager.NavigateTo("/users/chat");
            }

        }
    }
}