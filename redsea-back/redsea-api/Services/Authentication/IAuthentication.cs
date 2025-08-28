using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Authentication;

public interface IAuthentication
{
    public Task<bool> Login(string loginId, string password);

    public Task<bool> Logout(string clientId);

    public Task<bool> Register(Guid adminId, RegisterRequest registerRequest);
}
