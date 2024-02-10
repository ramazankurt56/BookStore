using BookStoreServer.WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreServer.WebApi.Services
{
    public sealed class JwtService
    {
        public string CreateToken(User appUser, bool rememberMe)
        {
            string token = string.Empty;

            List<Claim> claims = new();
            claims.Add(new("UserId", appUser.Id.ToString()));
            claims.Add(new("Name", appUser.GetName()));
            claims.Add(new("Email", appUser.Email ?? string.Empty));

            DateTime expires = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: "Ramazan Kurt",
                audience: "Book Store Angular App",
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my secret key my secret key my secret key 1234 ... my secret key my secret key my secret key 1234 ...")), SecurityAlgorithms.HmacSha512));

            JwtSecurityTokenHandler handler = new();
            token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}

