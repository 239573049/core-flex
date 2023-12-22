namespace TokenGpt.Rcl.Model;

/// <summary>
/// Top模型
/// </summary>
public class TopActionModel
{
    public string Title { get; set; } = string.Empty;
    
    public string Icon { get; set; } = string.Empty;

    public string Href { get; set; } = string.Empty;

    public bool IsSelect { get; set; }

    public bool Tooltip { get; set; }
}