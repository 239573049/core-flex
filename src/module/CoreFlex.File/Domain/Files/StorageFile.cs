using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace CoreFlex.File.Domain.Files;

public class StorageFile : FullAggregateRoot<string, long>
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("文件名不能为空");
            }

            _name = value;
        }
    }

    private int _size;

    /// <summary>
    /// 文件大小
    /// </summary>
    public int Size
    {
        get => _size;
        set => _size = value;
    }

    private string _type;

    public string Type
    {
        get => _type;
        set => _type = value;
    }
    
    private string _version;
    
    public string Version
    {
        get => _version;
        set => _version = value;
    }

    private byte[] _content;
    
    public byte[] Content
    {
        get => _content;
        set => _content = value;
    }

    protected StorageFile()
    {
    }

    public StorageFile(string id)
    {
        Id = id;
    }
}