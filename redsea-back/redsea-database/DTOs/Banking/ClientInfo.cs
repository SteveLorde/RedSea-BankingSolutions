namespace redsea_database.DTOs.Banking;

public record ClientInfo(
    string Name,
    string Work,
    string PhoneNumber,
    string Email) : TDTO;