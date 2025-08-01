namespace redsea_database.DTOs.Banking;

public record RegisterRequest(
    string Name,
    string Work,
    string PhoneNumber,
    string Email
    ) : TDTO;