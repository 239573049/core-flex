using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Commands;

namespace CoreFlex.File.Application.FileManager.Commands;

/// <summary>
/// 上传文件
/// </summary>
/// <param name="Name"></param>
/// <param name="ContentType"></param>
/// <param name="Content"></param>
/// <param name="Size"></param>
public record CreateFileCommand(string Name, string ContentType, byte[] Content, int Size) : Command
{
    public string Id;
}