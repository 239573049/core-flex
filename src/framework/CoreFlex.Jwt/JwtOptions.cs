namespace CoreFlex.Jwt;

/// <summary>
/// Jwt 配置
/// </summary>
public class JwtOptions
{
    /// <summary>
    /// 秘钥 （.NET 8开始强制key为256位）
    /// </summary>
    public static string Secret { get; protected set; }

    /// <summary>
    /// 有效时间（小时）
    /// </summary>
    public static int EffectiveHours { get; protected set; }

    /// <summary>
    /// 签发人
    /// </summary>
    public static string Issuer { get; protected set; }

    /// <summary>
    /// 接收者
    /// </summary>
    public static string Audience { get; protected set; }

    public JwtOptions(string secret,int effectiveHours,string issuer,string audience)
    {
        Secret = secret;
        EffectiveHours = effectiveHours;
        Issuer = issuer;
        Audience = audience;
    }
}