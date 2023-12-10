using CoreFlex.Chat.Server.Client;
using CoreFlex.Module.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Services.AddCoreFlexAutoInjectAsync<CoreFlexChatServerClientModule>();

var app = builder.Build();

await app.Services.UseCoreFlexAsync();

await app.RunAsync();
