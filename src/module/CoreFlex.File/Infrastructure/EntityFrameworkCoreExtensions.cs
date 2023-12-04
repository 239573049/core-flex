using CoreFlex.File.Domain.Files;
using Microsoft.EntityFrameworkCore;

namespace CoreFlex.File.Infrastructure;

public static class EntityFrameworkCoreExtensions
{
    /// <summary>
    /// 配置文件管理
    /// </summary>
    /// <param name="builder"></param>
    public static void ConfigureFileManager(this ModelBuilder builder)
    {
        builder.Entity<StorageFile>(options =>
        {
            options.ToTable("StorageFiles");
            
            options.HasKey(x => x.Id);
            options.Property(x => x.Id).IsRequired();
            
            options.Property(x => x.Name).HasMaxLength(20);
            
            options.Property(x=>x.Version).HasMaxLength(20);
            options.Property(x=>x.Type).HasMaxLength(20);
            
            options.Property(x => x.Size);

        });
    }
}