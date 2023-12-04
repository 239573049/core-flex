using System.Threading.Channels;
using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace CoreFlex.ChatGpt.Services.Domain.Chat.Aggregates;

/// <summary>
/// 频道，聚合根
/// 每一个聚合根都是一个独立的事务边界
/// </summary>
public class ChatChannel : FullAggregateRoot<long, long>
{
    private string _name;

    /// <summary>
    /// 名称
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("频道名称不能为空");
            }

            _name = value;
        }
    }

    private string _description;

    /// <summary>
    /// 描述
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("频道描述不能为空");
            }

            _description = value;
        }
    }

    private string _icon;

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon
    {
        get => _icon;
        set => _icon = value;
    }

    private string _model;

    /// <summary>
    /// 使用模型
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string Model
    {
        get => _model;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("频道模型不能为空");
            }

            _model = value;
        }
    }

    private string? _role;

    /// <summary>
    /// 设置角色
    /// </summary>
    public string? Role
    {
        get => _role;
        set => _role = value;
    }

    private int maxtoken = 2000;

    /// <summary>
    /// 最大响应token数
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int MaxToken
    {
        get => maxtoken;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("最大token数必须大于0");
            }

            maxtoken = value;
        }
    }

    private int maxhistory = 2;

    /// <summary>
    /// 最大历史记录数
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int MaxHistory
    {
        get => maxhistory;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("最大历史记录数必须大于0");
            }

            maxhistory = value;
        }
    }
    
    private int temperature = 0;
    
    /// <summary>
    /// 温度
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int Temperature
    {
        get => temperature;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("模板数必须大于等于0");
            }

            temperature = value;
        }
    }

    private string? key;
    
    /// <summary>
    /// 自定义key
    /// </summary>
    public string? Key
    {
        get => key;
        set => key = value;
    }
    
    private string? _endpoint;
    
    /// <summary>
    /// 端点
    /// </summary>
    public string? Endpoint
    {
        get => _endpoint;
        set => _endpoint = value;
    }

    protected ChatChannel()
    {
    }

    public ChatChannel(string name, string description, string model, string icon, string? role, int maxToken,
        int maxHistory, int temperature, string? key, string? endpoint)
    {
        Name = name;
        Description = description;
        Model = model;
        Icon = icon;
        Role = role;
        MaxToken = maxToken;
        MaxHistory = maxHistory;
        Temperature = temperature;
        Key = key;
        Endpoint = endpoint;
    }
}