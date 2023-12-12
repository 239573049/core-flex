/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 1
using CoreFlex.Chat.Rcl;

namespace CoreFlex.Chat.Server;

[DependOns(typeof(CoreFlexChatRclModule))]
public class CoreFlexChatServerModule : CoreFlexModule
{
    public override void OnApplicationShutdown(CoreFlexBuilder app)
    {

    }
}