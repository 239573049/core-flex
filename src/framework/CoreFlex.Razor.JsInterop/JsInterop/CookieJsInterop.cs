namespace CoreFlex.Razor.JsInterop.JsInterop;

/// <summary>
///  Cookie js封装
/// </summary>
public sealed class CookieJsInterop : JSModule, IScopedDependency
{
    public CookieJsInterop(IJSRuntime js) : base(js, PrefixPath + "cookie.js")
    {
    }

    /// <summary>
    /// 获取所有Cookie
    /// </summary>
    /// <returns></returns>
    public async ValueTask<string[]> GetAllCookiesAsync()
        => await InvokeAsync<string[]>("getAllCookies");

    /// <summary>
    /// 添加Cookie
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="expireTime"></param>
    /// <returns></returns>
    public async ValueTask AddCookieAsync(string name, string value, int? expireTime = null)
        => await InvokeVoidAsync("addCookie", name, value, expireTime);
}