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

        public JwtCreater(string email, string role)
        {
            Email = email;
            Role = role;
        }

        public string GetJwt()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:50133",
                audience: "http://localhost:50133",
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, Email),//
                    new Claim(ClaimTypes.Role, Role),//
                },
                expires: DateTime.Now.AddMinutes(99900),
                signingCredentials: signinCredentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        private string Role { get; }
        private string Email { get; }
    }
}
