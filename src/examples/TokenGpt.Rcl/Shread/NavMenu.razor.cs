using Microsoft.AspNetCore.Components;
using TokenGpt.Rcl.Model;

namespace TokenGpt.Rcl.Shread;

public partial class NavMenu
{
    [Parameter]
    public RenderFragment Avatar { get; set; }
    
    [Parameter]
    public List<TopActionModel> TopActions { get; set; } = new List<TopActionModel>();
    
    [Parameter]
    public RenderFragment BottomActions { get; set; }
    
    private void OnClick(TopActionModel topActionModel)
    {
        NavigationManager.NavigateTo(topActionModel.Href);
    }
}