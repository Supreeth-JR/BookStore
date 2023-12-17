using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common
{
    public class UserLogin
    {
        private IConfiguration configuration;
        private readonly HttpContext httpContext;
        private ISession session => httpContext.Session;//shortcut to writing a one liner method that returns something here return ISession
        public UserLogin(IConfiguration configuration, HttpContext httpContext)
        {
            this.configuration = configuration;
            this.httpContext = httpContext;
        }
        public UserLoginOutput GetUserLogin(UserLoginInput ObjInput)
        {
            UserLoginOutput ObjOutput = new ECommerceDAL("ConnectionString").ExecuteFirstModel<UserLoginOutput, UserLoginInput>
                ("USR.User_Login", ObjInput);
            if (ObjOutput?.IntUserID != 0)
            {
                string StrToken = GenerateJWT(ObjOutput);
                SetSession(ObjOutput);
                ObjOutput.StrToken = StrToken;
            }
            return ObjOutput;
        }
        private string GenerateJWT(UserLoginOutput ObjOutput)
        {
            //SymmetricSecurityKey -- Namespace - Microsoft.IdentityModel.Tokens
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var Credenticals = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var UserClaims = new[]
            {
                // Claim -- NameSpace - System.Security.Claims 
                new Claim(JwtRegisteredClaimNames.NameId, ObjOutput.IntUserID.ToString()), 
                new Claim(ClaimTypes.Role, ObjOutput?.StrUserRole)
            };
            var token = new JwtSecurityToken //JwtSecurityToken -- NameSpace - System.IdentityModel.Tokens.Jwt
                (
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    UserClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: Credenticals
                );
            IdentityModelEventSource.ShowPII = true; //IdentityModelEventSource -- NameSpace - Microsoft.IdentityModel.Logging
            return new JwtSecurityTokenHandler().WriteToken(token);           
        }
        private void SetSession(UserLoginOutput ObjOutput)
        {
            //HttpContext -- NameSpace - Microsoft.AspNetCore.Http
            session.SetString("SessionID", ObjOutput.strSession.ToString()); //SetString  -- NameSpace - Microsoft.AspNetCore.Http.Extensions
            session.SetString("UserID", ObjOutput.IntUserID.ToString());
        }
    }
}
