using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using redsea_database;

namespace redsea_api.Services.JWT;

public class JWT(IConfiguration config, ReadOnlyDataContext readOnlyDataContext) : IJWT
{
    public string GenerateToken(Guid userId, string userName)
    {
        var user = readOnlyDataContext.Clients.First(c => c.Id == userId);
        
        var secretKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["JWT:Secret"] ?? throw new InvalidOperationException("Secret Key not found")));
        
        var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName)
        };
        
        var tokenData = new JwtSecurityToken(
            issuer: "RedSea",
            audience: "RedSeaClient",
            claims: claims,
            expires: DateTime.Now.AddDays(2),
            signingCredentials: creds
        );
        
        var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

        return token;
    }
}