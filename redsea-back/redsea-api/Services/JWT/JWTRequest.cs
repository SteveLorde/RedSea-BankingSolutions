namespace redsea_api.Services.JWT;

public record JWTRequest(
    string Username,
    int UserType);
