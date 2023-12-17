using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common
{
    public class TokenAndSessionValidation
    {
        private readonly IConfiguration configuration;
        public TokenAndSessionValidation() //ActionExecutedContext -- NameSpace - Microsoft.AspNetCore.Mvc.Filters
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        public bool ValidateToke(ActionExecutingContext context)
        {
            string ObjOutput = context.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(ObjOutput))
            {
                if (ObjOutput.Split(' ').Length > 1)
                    ObjOutput = ObjOutput.Split(' ')[1];
                else
                    ObjOutput = ObjOutput.Split(' ')[0];
                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));//SymmetricSecurityKey -- Namespace - Microsoft.IdentityModel.Tokens
                var Credenticals = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                var UserClaims = new[]
                {
                  new Claim(JwtRegisteredClaimNames.NameId,context.HttpContext.Request.Headers["UserId"]), // Claim -- NameSpace - System.Security.Claims                  
                  new Claim(ClaimTypes.Role, context.HttpContext.Request.Headers["role"])
                };
                IdentityModelEventSource.ShowPII = true; //IdentityModelEventSource -- NameSpace - Microsoft.IdentityModel.Logging
                SecurityToken securityToken = null;
                try
                {
                    new JwtSecurityTokenHandler().ValidateToken(ObjOutput, new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = Key
                    }, out securityToken);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool SessionValidate(ActionExecutingContext context)
        {
            string HeaderSession = context.HttpContext.Request.Headers["Session"];
            string HeaderUserID = context.HttpContext.Request.Headers["UserId"];
            string CurrentSessionID = context.HttpContext.Session.GetString("SessionID");
            string CurrentUserID = context.HttpContext.Session.GetString("UserID");
            if (!string.IsNullOrEmpty(HeaderSession))
            {
                if (HeaderSession == CurrentSessionID && CurrentUserID == HeaderUserID)
                {
                    return true;
                }                
            }
            return false;
        }
    }
}
