using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using redsea_database;
using redsea_database.BankingModels;

namespace redsea_api.Services.JWT;

public class JWT(IConfiguration config, ReadOnlyDataContext readOnlyDataContext) : IJWT
{
    public string GenerateToken(Guid userId)
    {
        Client user = readOnlyDataContext.Clients.First(c => c.Id == userId);

        SymmetricSecurityKey secretKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["JWT:Secret"] ?? throw new InvalidOperationException("Secret Key not found")));

        SigningCredentials creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>();

        JwtSecurityToken tokenData = new JwtSecurityToken(
            "RedSea",
            "RedSeaClient",
            claims,
            expires: DateTime.Now.AddDays(2),
            signingCredentials: creds
        );

        string? token = new JwtSecurityTokenHandler().WriteToken(tokenData);

        return token;
    }
}
