namespace CoreFlex.Razor.JsInterop.JsInterop;

/// <summary>
/// Window js封装
/// </summary>
public sealed class WindowJsInterop : JSModule
{
    public WindowJsInterop(IJSRuntime js) : base(js, PrefixPath + "window.js")
    {
    }

    /// <summary>
    /// 使用 blob 创建 Blob Url
    /// </summary>
    /// <param name="jsObject"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public async ValueTask<string> CreateBlobURLAsync(IJSObjectReference jsObject, string type)
    {
        return await InvokeAsync<string>("createBlobURL", jsObject, type);
    }

    /// <summary>
    /// 使用byte[]创建一个 Blob  对象URL
    /// </summary>
    /// <param name="data"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public async ValueTask<string> CreateBlobURLFromUint8ArrayAsync(byte[] data, string type)
    {
        return await InvokeAsync<string>("createBlobURLFromUint8Array", data, type);
    }

    /// <summary>
    /// 使用Base64创建一个 Blob 对象的URL
    /// </summary>
    /// <param name="data">base64内容</param>
    /// <param name="type">文件类型</param>
    /// <returns></returns>
    public async ValueTask<string> CreateBlobURLFromStringAsync(string data, string type)
    {
        return await InvokeAsync<string>("createBlobURLFromString", data, type);
    }

    /// <summary>
    /// 释放 Blob 对象的 URL，
    /// </summary>
    /// <param name="url">需要被释放的url</param>
    /// <returns></returns>
    public async ValueTask RevokeUrlAsync(string url)
        => await InvokeVoidAsync("revokeUrl", url);

    /// <summary>
    /// 释放 Blob 对象的 URL，
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async ValueTask RevokeUrlsAsync(string[] url)
        => await InvokeVoidAsync("revokeUrls", url);

    /// <summary>
    /// 获取滚动条位置
    /// </summary>
    /// <param name="id">滚动条所在元素的</param>
    /// <returns>当前滚动条位置</returns>
    public async ValueTask<int> GetScrollPositionAsync(string id)
        => await InvokeAsync<int>("getScrollPosition", id);

    /// <summary>
    /// 修改滚动条位置
    /// </summary>
    /// <param name="id">滚动条所在元素的</param>
    /// <param name="targetPosition">目标滚动位置</param>
    /// <returns></returns>
    public async ValueTask SetScrollPositionAsync(string id, int targetPosition)
        => await InvokeVoidAsync("setScrollPosition", id, targetPosition);

    /// <summary>
    /// 获取滚动条高度
    /// </summary>
    /// <param name="id">滚动条所在元素的id</param>
    /// <returns>滚动条高度</returns>
    public async ValueTask<int> GetScrollHeightAsync(string id)
        => await InvokeAsync<int>("getScrollHeight", id);

    /// <summary>
    /// 滚动到底部
    /// </summary>
    /// <param name="id">滚动条所在元素的id</param>
    /// <returns></returns>
    public async ValueTask ScrollToBottomAsync(string id)
        => await InvokeVoidAsync("scrollToBottom", id);

    /// <summary>
    /// 滚动到滚动条顶部
    /// </summary>
    /// <param name="id">滚动条所在元素的id</param>
    /// <returns></returns>
    public async ValueTask ScrollToTopAsync(string id)
        => await InvokeVoidAsync("scrollToTop", id);

    /// <summary>
    /// 复制内容到剪贴板
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public async ValueTask CopyToClipboardAsync(string text)
        => await InvokeVoidAsync("copyToClipboard", text);
}