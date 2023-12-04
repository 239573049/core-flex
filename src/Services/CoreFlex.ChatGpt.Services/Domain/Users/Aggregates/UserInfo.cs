using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace CoreFlex.ChatGpt.Services.Domain.Users.Aggregates;

public class UserInfo : FullAggregateRoot<long, long>
{
    private string _account;

    public string Account
    {
        get => _account;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("账号不能为空");
            }

            _account = value;
        }
    }

    private string _password;

    public string Password
    {
        get => _password;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("密码不能为空");
            }

            _password = value;
        }
    }

    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("姓名不能为空");
            }

            _name = value;
        }
    }

    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("邮箱不能为空");
            }

            _email = value;
        }
    }

    private string _avatar;

    public string Avatar
    {
        get => _avatar;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("头像不能为空");
            }

            _avatar = value;
        }
    }

    private string? _gitee;

    public string? Gitee
    {
        get => _gitee;
        set => _gitee = value;
    }

    private string? _github;

    public string? Github
    {
        get => _github;
        set => _github = value;
    }

    protected UserInfo()
    {
    }

    public UserInfo(string account, string password, string name, string email, string avatar, string? gitee = null,
        string? github = null)
    {
        Account = account;
        Password = password;
        Name = name;
        Email = email;
        Avatar = avatar;
        Gitee = gitee;
        Github = github;
    }
}