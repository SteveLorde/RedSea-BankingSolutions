namespace redsea_api.Services.JWT;

public interface IJWT
{
    public string GenerateToken(Guid userId);
}
