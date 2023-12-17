namespace CoreFlex.Razor.JsInterop.JsInterop;

public class DocumentJsInterop : JSModule, IScopedDependency
{
    public DocumentJsInterop(IJSRuntime js) : base(js, PrefixPath + "document.js")
    {
    }

    /// <summary>
    /// 点击指定元素
    /// </summary>
    /// <param name="id"></param>
    public async ValueTask ClickDocumentAsync(string id)
        => await InvokeVoidAsync("clickDocument", id);

    /// <summary>
    /// 点击指定元素
    /// </summary>
    /// <param name="element"></param>
    public async ValueTask ClickElementAsync(IJSObjectReference element)
        => await InvokeVoidAsync("clickElement", element);

    /// <summary>
    /// 获取指定元素
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async ValueTask<IJSObjectReference?> GetElementByIdAsync(string id)
        => await InvokeAsync<IJSObjectReference>("getElementById", id);

    /// <summary>
    /// 判断指定id的元素是否存在
    /// </summary>
    public async ValueTask<bool> HasElementByIdAsync(string id)
        => await InvokeAsync<bool>("hasElementById", id);
}