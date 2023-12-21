using Microsoft.AspNetCore.Components;

namespace TokenGpt.Rcl.Shread;

public partial class NavMenu
{
    [Parameter]
    public RenderFragment Avatar { get; set; }
    
    [Parameter]
    public RenderFragment TopActions { get; set; }
    
    [Parameter]
    public RenderFragment BottomActions { get; set; }
}