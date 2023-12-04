using CoreFlex.Application.Core;
using CoreFlex.EntityFrameworkCore;
using CoreFlex.File.Application.FileManager.Commands;
using CoreFlex.File.Domain.Files;
using Masa.Contrib.Dispatcher.Events;
using Microsoft.Extensions.Options;

namespace CoreFlex.File.Application.FileManager;

public class CommandHandler : ApplicationService
{
    protected readonly ICoreFlexRepository<StorageFile, string> _repository;

    public CommandHandler(IServiceProvider serviceProvider, ICoreFlexRepository<StorageFile, string> repository) : base(
        serviceProvider)
    {
        _repository = repository;
    }

    [EventHandler]
    public async Task CreateFileAsync(CreateFileCommand command)
    {
        var options = GetService<IOptions<FileManagerOptions>>()?.Value ?? new FileManagerOptions();

        if (await _repository.GetCountAsync(x => x.Creator == GetUserContext().GetUserId<long>()) > options.MaxSize)
            throw new Exception("文件数量超过限制");

        // 获取昨天24点
        var yesterday = DateTime.Now.AddDays(-1).Date.AddDays(1);

        var count = await _repository.GetCountAsync(x =>
            x.CreationTime > yesterday && x.Creator == GetUserContext().GetUserId<long>());

        if (count > options.MaxSize)
            throw new Exception("您今天上传的文件已经达到上限，请明天再试!");

        var file = new StorageFile(Guid.NewGuid().ToString("N"))
        {
            Name = command.Name,
            Type = command.ContentType,
            Size = command.Size,
            Content = command.Content
        };

        await _repository.AddAsync(file);
    }
}