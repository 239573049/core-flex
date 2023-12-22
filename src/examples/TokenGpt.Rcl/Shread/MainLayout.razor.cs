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
            Title = "首页",
            IsSelect = true
        });
        _topActionModels.Add(new TopActionModel()
        {
            Href = "/application",
            Icon = "mdi-application",
            Title = "应用",
            IsSelect = false
        });
        _topActionModels.Add(new TopActionModel()
        {
            Href = "/knowledge-base",
            Icon = "mdi-bookmark-box",
            Title = "知识库",
            IsSelect = false
        });
    }
}