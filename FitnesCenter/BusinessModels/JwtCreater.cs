using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnesCenter.BusinessModels
{
    public class JwtCreater
    {
        public const string SECRET_KEY = "superSecretKey@345";

        public JwtCreater(string email, string role, string isFirstEntry)
        {
            Email = email;
            Role = role;
            IsFirstEntry = isFirstEntry;
        }

        public string GetJwt()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:44382",
                audience: "https://localhost:44382",
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, Email),//
                    new Claim(ClaimTypes.Role, Role),
                    new Claim("IsFirstEntry", IsFirstEntry)//
                },
                expires: DateTime.Now.AddMinutes(99900),
                signingCredentials: signinCredentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        private string Role { get; }
        private string Email { get; }
        private string IsFirstEntry { get; }
    }
}
