using BookBorrowDLL.Repositary.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowBLL
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Duration { get; set; }

        public Jwt(string? Key, string? Duration)
        {
            this.Key = Key ?? "";
            this.Duration = Duration ?? "";
        }

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("id",user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("username", user.Username),
                new Claim("tokenAvailable", user.TokenAvailable.ToString())
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(Int32.Parse(this.Duration)),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
