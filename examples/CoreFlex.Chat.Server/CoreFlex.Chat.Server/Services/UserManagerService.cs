/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
using System.Collections.Concurrent;

namespace CoreFlex.Chat.Server.Services;

public class UserManagerService : IUserManagerService, IScopedDependency
{
    private static readonly ConcurrentDictionary<string, UserManagerDto> _concurrentDictionary = new();

    private static Action<UserStatus, CurrentUserInfo> _userStatusHandler;

    private Action<UserStatus, CurrentUserInfo> _currentUserInfoHandler;

    public async Task AddUserInfoAsync(CurrentUserInfo userInfo)
    {
        _concurrentDictionary.TryAdd(userInfo.Id, new UserManagerDto(userInfo)
        {
            Status = UserStatus.Online
        });

        // 通知订阅事件用户上线
        _userStatusHandler?.Invoke(UserStatus.Online, userInfo);

        await Task.CompletedTask;
    }

    public async Task RemoveUserInfoAsync(CurrentUserInfo userInfo)
    {
        if (userInfo == null)
        {
            return;
        }

        if (_concurrentDictionary.TryGetValue(userInfo.Id, out var value))
        {
            value.LastOfflineTime = DateTime.Now;
            value.Status = UserStatus.Offline;
        }

        _userStatusHandler?.Invoke(UserStatus.Offline, userInfo);

        await Task.CompletedTask;
    }

    public async Task Subscription(Action<UserStatus, CurrentUserInfo> userInfo)
    {
        _currentUserInfoHandler = userInfo;
        _userStatusHandler += _currentUserInfoHandler;

        await Task.CompletedTask;
    }

    public Task<List<UserManagerDto>> GetUserInfoAsync()
    {
        return Task.FromResult(_concurrentDictionary.Select(x => x.Value).ToList());
    }

    public void Dispose()
    {
        if (_userStatusHandler != null && _currentUserInfoHandler != null)
        {
            _userStatusHandler -= _currentUserInfoHandler;
        }
    }
}