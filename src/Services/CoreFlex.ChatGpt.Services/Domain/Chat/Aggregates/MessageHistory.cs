using Masa.BuildingBlocks.Ddd.Domain.Entities;
using Masa.BuildingBlocks.Ddd.Domain.Entities.Auditing;

namespace CoreFlex.ChatGpt.Services.Domain.Chat.Aggregates;

public class MessageHistory : Entity<long>,IAuditEntity<long>
{
    /// <summary>
    /// 绑定频道
    /// </summary>
    public long ChatChannelId { get; set; }

    /// <summary>
    /// 是否本人发送
    /// </summary>
    public bool Curren { get; set; }
    
    /// <summary>
    /// 发送内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 记录类型
    /// </summary>
    public string Type { get; set; }
    
    public long Creator { get; set; }
    
    public DateTime CreationTime { get;set; }
    
    public long Modifier { get; set;}
    
    public DateTime ModificationTime { get;set; }

    protected MessageHistory()
    {
    }

    public MessageHistory(long chatChannelId, bool curren, string content, string type)
    {
        ChatChannelId = chatChannelId;
        Curren = curren;
        Content = content;
        Type = type;
    }
}