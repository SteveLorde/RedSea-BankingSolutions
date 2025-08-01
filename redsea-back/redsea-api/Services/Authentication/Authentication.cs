using Microsoft.EntityFrameworkCore;
using redsea_api.Services.Hash;
using redsea_database;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Authentication;

public class Authentication(ReadOnlyDataContext readOnlyDataContext, IConfiguration envConfig) : IAuthentication
{
    public async Task<bool> Login(string loginId, string password)
    {
        // Fetch and Verify User Data
        var user = await readOnlyDataContext.Clients.FirstAsync(c => c.Id == Guid.Parse(loginId));

        if (user == null)
        {
            return false;
        }
        
        var check = Hashing.VerifyHash(password, user.HashedPassword, envConfig["PassSalt"]);
        
        return await Task.FromResult(check);
    }

    public async Task<bool> Logout(string clientId)
    {
        return true;
    }

    public async Task<bool> Register(Guid adminId, RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }
}