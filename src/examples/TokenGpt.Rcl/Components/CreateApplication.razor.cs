using BlazorComponent;
using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components;
using TokenGpt.Contract.Services.Dto;

namespace TokenGpt.Rcl.Components;

public partial class CreateApplication
{
    [Parameter] public EventCallback OnSucceed { get; set; }

    public ApplicationInput Input { get; set; } = new();

    public bool Open { get; set; }

    private void Callback()
    {
        Input = new ApplicationInput();
        Open = false;
    }


    private async Task OnOK()
    {
        if (string.IsNullOrEmpty(Input.Name))
        {
            await PopupService.EnqueueSnackbarAsync(new SnackbarOptions("名称不能为空", AlertTypes.Error));
            return;
        }

        if (string.IsNullOrEmpty(Input.Model))
        {
            await PopupService.EnqueueSnackbarAsync(new SnackbarOptions("模型不能为空", AlertTypes.Error));
            return;
        }
        
        if (string.IsNullOrEmpty(Input.Prologue))
        {
            await PopupService.EnqueueSnackbarAsync(new SnackbarOptions("前言不能为空", AlertTypes.Error));
            return;
        }
        
        if (string.IsNullOrEmpty(Input.Description))
        {
            await PopupService.EnqueueSnackbarAsync(new SnackbarOptions("描述不能为空", AlertTypes.Error));
            return;
        }

        await ApplicationService.CreateAsync(Input);
        Open = false;
        await OnSucceed.InvokeAsync();
    }
}