using TokenGpt.Rcl.Model;

namespace TokenGpt.Rcl.Shread;

public partial class MainLayout
{
    private List<TopActionModel> _topActionModels = new List<TopActionModel>();

    protected override void OnInitialized()
    {
        _topActionModels.Add(new TopActionModel()
        {
            Href = "/",
            Icon = "mdi-home",
            Title = "首页"
        });
    }
}