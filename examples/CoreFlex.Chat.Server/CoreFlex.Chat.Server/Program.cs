/// core-flex-chat © 2023-12-13 by 贺家乐 is licensed under Attribution-NonCommercial-ShareAlike 4.0 International 
using CoreFlex.Chat.Rcl;
using CoreFlex.Chat.Server;
using CoreFlex.Chat.Server.Components;
using CoreFlex.Module.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

await builder.AddCoreFlexAutoInjectAsync<CoreFlexChatServerModule>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication(); // ��֤ 
app.UseAuthorization(); // ��Ȩ

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(CoreFlexChatRclModule).Assembly);

await app.Services.UseCoreFlexAsync();

app.Run();
