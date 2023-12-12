/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
namespace CoreFlex.Chat.Contract;

public class UserManagerDto : CurrentUserInfo
{
    /// <summary>
    /// 上次离线时间
    /// </summary>
    public DateTime LastOfflineTime { get; set; }

    public UserStatus Status { get; set; }

    public UserManagerDto(CurrentUserInfo userInfo)
    {
        Name = userInfo.Name;
        Ip = userInfo.Ip;
        Id = userInfo.Id;
    }
}