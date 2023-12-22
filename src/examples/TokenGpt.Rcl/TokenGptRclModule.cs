using CoreFlex.Module;
using CoreFlex.Razor.JsInterop;
using Microsoft.Extensions.DependencyInjection;

namespace TokenGpt.Rcl;

[DependOns(typeof(CoreFlexRazorJsInteropModule))]
public class TokenGptRclModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Services.AddMasaBlazor(options => { options.ConfigureSsr(); });
        
        Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
        {
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=tokenGpt.db")
                .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
                .Build();
            return fsql;
        };

        context.Services.AddAutoMapper(typeof(TokenGptRclModule));
        context.Services.AddSingleton<IFreeSql>(fsqlFactory);
    }
}