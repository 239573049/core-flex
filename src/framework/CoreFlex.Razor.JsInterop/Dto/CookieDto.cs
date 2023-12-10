namespace CoreFlex.Razor.JsInterop.Dto;

public class CookieDto
{
    /// <summary>
    /// 获取或设置 Cookie 的域名
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 的过期时间
    /// </summary>
    public DateTime? Expires { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 的名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 是否分区
    /// </summary>
    public bool Partitioned { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 的路径
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 的 SameSite 属性
    /// </summary>
    public string SameSite { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 是否安全
    /// </summary>
    public bool Secure { get; set; }

    /// <summary>
    /// 获取或设置 Cookie 的值
    /// </summary>
    public string Value { get; set; }
}