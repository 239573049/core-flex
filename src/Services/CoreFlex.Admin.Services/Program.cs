using CoreFlex.Admin.Services;
using CoreFlex.Module.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.AddCoreFlexAutoInjectAsync<CoreFlexAdminServiceModule>();

var app = builder.Build();

await app.UseCoreFlexAsync();

app.Run();