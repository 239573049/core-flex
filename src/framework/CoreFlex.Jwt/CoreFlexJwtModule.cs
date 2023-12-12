using CoreFlex.Module;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CoreFlex.Jwt;

public class CoreFlexJwtModule : CoreFlexModule
{
    public override void ConfigureServices(CoreFlexServiceContext context)
    {
        context.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        if (string.IsNullOrEmpty(JwtOptions.Secret))
        {
            throw new ArgumentNullException(nameof(JwtOptions.Secret));
        }

        var tokenValidation = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtOptions.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        if (!string.IsNullOrEmpty(JwtOptions.Issuer))
        {
            tokenValidation.ValidIssuer = JwtOptions.Issuer;
        }

        if (!string.IsNullOrEmpty(JwtOptions.Audience))
        {
            tokenValidation.ValidAudience = JwtOptions.Audience;
        }

        //使用应用密钥得到一个加密密钥字节数组
        context.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cfg => cfg.SlidingExpiration = true)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidation;
            });

    }

}