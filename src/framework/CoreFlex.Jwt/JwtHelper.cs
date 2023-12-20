using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoreFlex.Jwt;

/// <summary>
/// Jwt相关工具
/// </summary>
public class JwtHelper
{
    /// <summary>
    /// 生成token
    /// </summary>
    /// <param name="claimsIdentity"></param>
    /// <returns></returns>
    public static string GeneratorAccessToken(IDictionary<string, object> claimsIdentity)
    {
        return GeneratorAccessToken(JwtOptions.Secret, claimsIdentity, JwtOptions.EffectiveHours);
    }

    /// <summary>
    /// 生成token
    /// </summary>
    /// <param name="securityKey"></param>
    /// <param name="claimsIdentity"></param>
    /// <param name="effectiveHours"></param>
    /// <param name="algorithm"></param>
    /// <returns></returns>
    public static string GeneratorAccessToken(string securityKey, IDictionary<string, object> claimsIdentity,int effectiveHours, string algorithm = SecurityAlgorithms.HmacSha256)
    {
        var claims = new ClaimsIdentity();
        foreach (var o in claimsIdentity)
        {
            if (o.Value.GetType().IsValueType)
                claims.AddClaim(new Claim(o.Key, o.Value.ToString()));
            else if (o.Value.GetType() == typeof(string))
                claims.AddClaim(new Claim(o.Key, o.Value.ToString()));
            else
                claims.AddClaim(new Claim(o.Key, JsonSerializer.Serialize(o.Value)));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(securityKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddHours(effectiveHours),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), algorithm)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// 校验token是否过期
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public static bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;

            // 校验是否过期
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                return false; // Token已过期
            }

            // 获取指定类型的值
            var userId = GetClaimValue(principal, ClaimTypes.NameIdentifier);
            var userEmail = GetClaimValue(principal, ClaimTypes.Email);

            return true; // Token有效
        }
        catch (Exception)
        {
            return false; // Token无效
        }
    }

    /// <summary>
    /// 解析Token获取指定ClaimType
    /// </summary>
    /// <param name="token"></param>
    /// <param name="claimType"></param>
    /// <returns></returns>
    public static string? GetClaimValue(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

        var claim = principal.FindFirst(claimType);
        return claim?.Value;
    }

    /// <summary>
    /// 解析Token获取指定ClaimType
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="token"></param>
    /// <param name="claimType"></param>
    /// <returns></returns>
    public static T GetClaimValue<T>(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

        var claim = principal.FindFirst(claimType);
        return JsonSerializer.Deserialize<T>(claim?.Value);
    }

    /// <summary>
    /// 解析ClaimsPrincipal获取指定ClaimType
    /// </summary>
    /// <param name="principal"></param>
    /// <param name="claimType"></param>
    /// <returns></returns>
    public static string GetClaimValue(ClaimsPrincipal principal, string claimType)
    {
        var claim = principal.FindFirst(claimType);
        return claim?.Value;
    }
}