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
    public async ValueTask<CookieDto[]> GetAllCookiesAsync()
        => await InvokeAsync<CookieDto[]>("getAllCookies");

    /// <summary>
    /// 添加Cookie
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async ValueTask AddCookieAsync(CookieDto dto)
        => await InvokeVoidAsync("addCookie", dto);
}