/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Contract;

public interface IUserManagerService : IDisposable
{
    /// <summary>
    /// 添加新用户上线
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task AddUserInfoAsync(CurrentUserInfo userInfo);

    /// <summary>
    /// 删除用户离线
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task RemoveUserInfoAsync(CurrentUserInfo userInfo);

    /// <summary>
    /// 订阅用户上线和下线
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task Subscription(Action<UserStatus,CurrentUserInfo> userInfo);

    /// <summary>
    /// 获取所有用户列表
    /// </summary>
    /// <returns></returns>
    Task<List<UserManagerDto>> GetUserInfoAsync();
}