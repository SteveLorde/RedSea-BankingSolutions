namespace redsea_database.DTOs.Banking;

public record ClientGeneralFinances(
    Guid ClientId, 
    float Balance,
    float CertificatesBalance);