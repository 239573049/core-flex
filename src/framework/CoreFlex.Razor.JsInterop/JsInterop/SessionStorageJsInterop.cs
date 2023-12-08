namespace CoreFlex.Razor.JsInterop.JsInterop;

/// <summary>
///  SessionStorage js封装
/// </summary>
public sealed class SessionStorageJsInterop : JSModule, IScopedDependency
{
    public SessionStorageJsInterop(IJSRuntime js) : base(js, PrefixPath + "sessionStorage.js")
    {
    }
    
    /// <summary>
    /// 设置SessionStorage的值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async ValueTask SetSessionStorageAsync<T>(string key, T value) where T : class
        => await SetSessionStorageAsync(key, JsonSerializer.Serialize(value));

    /// <summary>
    /// 获取SessionStorage的值
    /// </summary>
    /// <typeparam name="T">指定class类型</typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public async ValueTask<T?> GetSessionStorageAsync<T>(string key) where T : class
        => JsonSerializer.Deserialize<T>(await GetSessionStorageAsync(key));

    /// <summary>
    /// 设置SessionStorage的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async ValueTask SetSessionStorageAsync(string key, string value)
        => await InvokeVoidAsync("setSessionStorage", key, value);

    /// <summary>
    /// 获取SessionStorage的值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async ValueTask<string> GetSessionStorageAsync(string key)
        => await InvokeAsync<string>("getSessionStorage", key);

    /// <summary>
    /// 删除指定Key的SessionStorage
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async ValueTask RemoveSessionStorageAsync(string key)
        => await InvokeVoidAsync("removeSessionStorage", key);

    /// <summary>
    /// 批量删除Key的SessionStorage
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public async ValueTask RemovesSessionStorageAsync(string[] keys)
        => await InvokeVoidAsync("removesSessionStorage", keys);

    /// <summary>
    /// 清空SessionStorage
    /// </summary>
    /// <returns></returns>
    public async ValueTask ClearSessionStorageAsync()
        => await InvokeVoidAsync("clearSessionStorage");

    /// <summary>
    /// 获取 sessionStorage 中的键名
    /// </summary>
    /// <returns></returns>
    public async ValueTask<string[]> GetSessionStorageKeysAsync()
        => await InvokeAsync<string[]>("getSessionStorageKeys");

    /// <summary>
    /// 判断 sessionStorage 中是否含有某个键名
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async ValueTask<bool> ContainKeyAsync(string key)
        => await InvokeAsync<bool>("containKey", key);

    /// <summary>
    /// 获取 sessionStorage 中值的数量
    /// </summary>
    /// <returns></returns>
    public async ValueTask<int> GetSessionStorageLengthAsync()
        => await InvokeAsync<int>("getSessionStorageLength");
}