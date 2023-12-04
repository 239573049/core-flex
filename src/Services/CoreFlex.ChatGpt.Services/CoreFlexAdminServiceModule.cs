using CoreFlex.Application.Core;
using CoreFlex.ChatGpt.Services.DataAccess;
using CoreFlex.EntityFrameworkCore;
using CoreFlex.File;
using CoreFlex.File.Domain.Files;
using CoreFlex.Module;
using CoreFlex.RateLimiting;
using Masa.BuildingBlocks.Data.UoW;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CoreFlex.ChatGpt.Services;

[DependOns(typeof(CoreFlexRateLimitingModule), typeof(CoreFlexFileModule))]
public class CoreFlexAdminServiceModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        
        context.Services
            .AddScoped<ICoreFlexRepository<StorageFile, string>,
                CoreFlexRepository<CoreFlexDbContext, StorageFile, string>>();
        
        context.Services.AddEndpointsApiExplorer();
        context.Services.AddAntiforgery();
        context.Services.AddEventBus();
        context.Services.AddAuthorization();
        context.Services.AddAuthentication();
        context.Services.AddMasaMinimalAPIs(options =>
        {
            options.Version = "v1";
            options.Assemblies = new[]
            {
                typeof(CoreFlexAdminServiceModule).Assembly,
                typeof(ApplicationService).Assembly,
                typeof(CoreFlexFileModule).Assembly
            };
        });
        context.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "CoreFlex Admin Service",
                    Version = "v1",
                    Contact = new OpenApiContact { Name = "CoreFlex Admin" }
                });
            foreach (var item in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml"))
                options.IncludeXmlComments(item, true);
            options.DocInclusionPredicate((docName, action) => true);
        });

        context.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", corsBuilder =>
            {
                corsBuilder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        context.Services.AddMasaDbContext<CoreFlexDbContext>(options =>
        {
            options.UseSqlite(context.Configuration["ConnectionStrings:DefaultConnection"])
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
        });

        context.Services.AddDomainEventBus(options =>
        {
            options.UseUoW<CoreFlexDbContext>()
                .UseRepository<CoreFlexDbContext>();
        });
    }

    public override void OnApplicationShutdown(WebApplication app)
    {
        app.MapMasaMinimalAPIs();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger()
                .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreFlex Admin"));
        }

        app.UseAuthentication();
        app.UseAuthorization()
            .UseCors("CorsPolicy");
    }
}