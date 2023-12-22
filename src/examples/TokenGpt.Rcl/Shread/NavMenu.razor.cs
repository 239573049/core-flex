using BlazorComponent;
using Microsoft.AspNetCore.Components;
using TokenGpt.Rcl.Model;

namespace TokenGpt.Rcl.Shread;

public partial class NavMenu
{
    [Parameter]
    public RenderFragment Avatar { get; set; }

    [Parameter]
    public List<TopActionModel> TopActions { get; set; } = new();

    [Parameter]
    public RenderFragment BottomActions { get; set; }

    private void OnClick(TopActionModel topActionModel)
    {
        TopActions.Where(x=>x.IsSelect).ForEach(x =>
        {
            x.IsSelect = false;
        });

        NavigationManager.NavigateTo(topActionModel.Href);
        topActionModel.IsSelect = true;
    }
}