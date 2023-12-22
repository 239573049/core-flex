using BlazorComponent;
using TokenGpt.Contract.Services.Dto;

namespace TokenGpt.Rcl.Pages;

public partial class Application
{
    private List<ApplicationDto> _knowledgeBaseEntities = new List<ApplicationDto>();

    private async Task LoadingKnowledgeBase()
    {
        _knowledgeBaseEntities = await ApplicationService.GetListAsync(string.Empty);
    }

    private async Task OnCreate()
    {
        await LoadingKnowledgeBase();
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadingKnowledgeBase();
    }

}