﻿using CoreFlex.Jwt;
using CoreFlex.Module;
using CoreFlex.Razor.JsInterop;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFlex.Chat.Rcl;

[DependOns(typeof(CoreFlexRazorJsInteropModule),typeof(CoreFlexJwtModule))]
public class CoreFlexChatRclModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.AddMasaBlazor(options =>
        {
            options.ConfigureIcons(IconSet.MaterialDesign);
            options.ConfigureIcons(IconSet.MaterialDesignIcons);
        });

    }
}