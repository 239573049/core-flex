using CoreFlex.File.Domain.Files;
using CoreFlex.File.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoreFlex.ChatGpt.Services.DataAccess;

public class CoreFlexDbContext : MasaDbContext<CoreFlexDbContext>
{
    public DbSet<StorageFile> StorageFiles { get; set; } = null!;
    
    protected override void OnModelCreatingExecuting(ModelBuilder builder)
    {
        builder.ConfigureFileManager();
    }
}