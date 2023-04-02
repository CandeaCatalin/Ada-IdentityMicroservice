using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityMicroservice.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityMicroservice.Services
{
    public static class JwtService
    {
        private const string SECRET_KEY = "nVsc7jp9Kv1pnyqLyeyYsbQNyK7RjLuYh2erLN0VMb7KMuTR1RkHvH32AHeXKxJa";
        public static string GenerateToken(User existingUser,IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = GenerateClaims(existingUser, roles);
            var tokenDescriptor = GenerateTokenDescriptor(claims);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static SecurityTokenDescriptor GenerateTokenDescriptor(List<Claim> claims)
        {
            var key = Encoding.ASCII.GetBytes(SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
        private static List<Claim> GenerateClaims(User existingUser, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, existingUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, existingUser.Email),
                new Claim(ClaimTypes.Name, existingUser.FirstName + " " + existingUser.LastName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            return claims;
        }
    }
}