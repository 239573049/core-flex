using CoreFlex.Chat.Rcl;
using CoreFlex.Chat.Server;
using CoreFlex.Chat.Server.Client;
using CoreFlex.Chat.Server.Components;
using CoreFlex.Module.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

await builder.Services.AddCoreFlexAutoInjectAsync<CoreFlexChatServerModule>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CoreFlexChatServerClientModule).Assembly)
    .AddAdditionalAssemblies(typeof(CoreFlexChatRclModule).Assembly);

await app.Services.UseCoreFlexAsync();

app.Run();
