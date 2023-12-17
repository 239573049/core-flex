namespace CoreFlex.Razor.JsInterop.JsInterop;

/// <summary>
/// IndexedDb js封装
/// </summary>
public class IndexedDbJsInterop : JSModule, IScopedDependency
{
    public IndexedDbJsInterop(IJSRuntime js) : base(js, PrefixPath + "indexedDbHelper.js")
    {
    }

    /// <summary>
    /// 打开IndexedDb初始化
    /// </summary>
    /// <param name="id"></param>
    /// <param name="databaseName"></param>
    /// <param name="version"></param>
    /// <param name="storeName"></param>
    /// <returns></returns>
    public async ValueTask OpenAsync(string id, string databaseName, int version, string storeName)
        => await InvokeVoidAsync("open", id, databaseName, version, storeName);

    /// <summary>
    /// 查询指定storeName的所有数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <returns></returns>
    public async ValueTask<T> GetAllAsync<T>(string id, string storeName)
        => await InvokeAsync<T>("getAll", id, storeName);

    /// <summary>
    /// 根据指定分页查询storeName数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public async ValueTask<T> GetPageAsync<T>(string id, string storeName, int page, int pageSize)
        => await InvokeAsync<T>("get", id, storeName, page, pageSize);

    /// <summary>
    /// 添加数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async ValueTask AddAsync<T>(string id, string storeName, T value)
        => await InvokeVoidAsync("add", id, storeName, value);

    /// <summary>
    /// 更新指定数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async ValueTask UpdateAsync<T>(string id, string storeName, T value)
        => await InvokeVoidAsync("update", id, storeName, value);

    /// <summary>
    /// 删除指定key
    /// </summary>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public async ValueTask RemoveAsync(string id, string storeName, string key)
        => await InvokeVoidAsync("remove", id, storeName, key);

    /// <summary>
    /// 清空指定storeName的所有数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <returns></returns>
    public async ValueTask ClearAsync(string id, string storeName)
        => await InvokeVoidAsync("clear", id, storeName);

    /// <summary>
    /// 批量删除key
    /// </summary>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public async ValueTask RemovesAsync(string id, string storeName, string[] key)
        => await InvokeVoidAsync("removes", id, storeName, key);

    /// <summary>
    /// 统计storeName的数据总数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="storeName"></param>
    /// <returns></returns>
    public async ValueTask CountAsync(string id, string storeName)
        => await InvokeVoidAsync("count", id, storeName);

    public override async ValueTask DisposeAsync()
    {
        await InvokeVoidAsync("close");
        await base.DisposeAsync();
    }
}