/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
using System;

namespace CoreFlex.Chat.Server.Services;

public class UserService : IUserService, IScopedDependency
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<string> GetTokenAsync(string name)
    {
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
        {
            ip = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
        }

        var currentUser = new CurrentUserInfo()
        {
            Id = Guid.NewGuid().ToString("N"),
            Ip = ip,
            Name = name
        };

        var info = new Dictionary<string, object>
        {
            { "id" , Guid.NewGuid().ToString("N")},
            {Constant.Rcl.UserInfo,currentUser}
        };
        var token = JwtHelper.GeneratorAccessToken(info);

        return Task.FromResult(token);
    }
}