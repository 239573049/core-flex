using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace TokenGpt.Rcl.Components;

public partial class MenuButton
{
    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public StringNumber Width { get; set; } = "45px";

    [Parameter] public StringNumber Height { get; set; } = "45px";

    [Parameter] public StringNumber BorderRadius { get; set; } = "8px";

    [Parameter] public bool Icon { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter] public bool IsSelect { get; set; }

    private string GetClass => IsSelect ? "menu-button menu-button-select" : "menu-button";
 
    private string GetStyle => $"border-radius:{BorderRadius};";
    
    private async Task OnClickHandler(MouseEventArgs e)
    {
        await OnClick.InvokeAsync(e);
    }
}