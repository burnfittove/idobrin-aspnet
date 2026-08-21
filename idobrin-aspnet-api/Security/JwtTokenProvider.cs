using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace idobrin_aspnet_api.Security;

public class JwtTokenProvider
{
    public static string CreateToken(string secureKey, int expiration, string role, string subject = null)
    {
        // Get secret key bytes
        var tokenKey = Encoding.UTF8.GetBytes(secureKey);

        // Create a token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(expiration),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature),
            IssuedAt = DateTime.UtcNow
        };

        if (!string.IsNullOrEmpty(role))
        {
            if (!string.IsNullOrEmpty(subject))
            {
                tokenDescriptor.Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.Name, subject),
                    new Claim(JwtRegisteredClaimNames.Sub, subject),
                    new Claim(ClaimTypes.Role, role)
                ]);
            }
            else
            {
                tokenDescriptor.Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.Role, role)
                ]);
            }
        }

        // Create token using that descriptor, serialize it and return it
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var serializedToken = tokenHandler.WriteToken(token);
            
        return serializedToken;
    }
}