namespace CoreFlex.Chat.Rcl.Modules;

/// <summary>
/// 菜单项
/// </summary>
public class ChatMenuItem : BaseDto<string>
{
    private string _name;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name
    {
        get => _name;
        protected set => _name = value;
    }

    private string _description;

    /// <summary>
    /// 描述
    /// </summary>
    public string Description
    {
        get => _description;
        protected set => _description = value;
    }

    private string _role;

    /// <summary>
    /// 角色
    /// </summary>
    public string Role
    {
        get => _role;
        protected set => _role = value;
    }

    private int _maxToken = 2000;

    /// <summary>
    /// 最大token
    /// </summary>
    public int MaxToken
    {
        get => _maxToken;
        protected set => _maxToken = value;
    }

    private string _model;

    /// <summary>
    /// 使用模型
    /// </summary>
    public string Model
    {
        get => _model;
        set => _model = value;
    }

    private string _newMessage;

    /// <summary>
    /// 最新一次内容
    /// </summary>
    public string NewMessage
    {
        get => _newMessage;
        set => _newMessage = value;
    }

    private DateTime? _lastUpdate;

    /// <summary>
    /// 最新更新时间
    /// </summary>
    public DateTime? LastUpdate
    {
        get => _lastUpdate;
        set => _lastUpdate = value;
    }

    /// <summary>
    /// 当前状态
    /// </summary>
    public UserStatus Status { get; set; }

    public string StatusName
    {
        get
        {
            switch (Status)
            {
                case UserStatus.Offline:
                    return "离线";
                case UserStatus.Online:
                    return "在线";
            }

            return "";
        }
    }

    protected ChatMenuItem()
    {

    }

    public ChatMenuItem(string id, string name, string description,string model, string role = "", int maxToken = 2000)
    {
        UpdateName(name);
        UpdateMaxToken(maxToken);
        Id = id;
        Model = model;
        CreatedTime = DateTime.Now;
        Description = description;
        Role = role;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(Name));
        }

        Name = name;
    }

    public void UpdateMessage(string newMessage)
    {
        NewMessage = newMessage;
        LastUpdate=DateTime.Now;
    }

    public void UpdateMaxToken(int maxToken)
    {
        if (maxToken < 500)
        {
            throw new Exception("最大token不能小于500");
        }

        MaxToken = maxToken;
    }
}