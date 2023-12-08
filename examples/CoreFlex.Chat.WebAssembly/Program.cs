using CoreFlex.Chat.WebAssembly;
using CoreFlex.Module.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await builder.Services.AddCoreFlexAutoInjectAsync<CoreFlexChatWebAssemblyModule>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var app = builder.Build();

await app.Services.UseCoreFlexAsync();

await app.RunAsync();
