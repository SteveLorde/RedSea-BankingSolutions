namespace redsea_database.DTOs.Banking;

public record ClientGeneralFinances(
    Guid ClientId,
    decimal Balance,
    decimal CertificatesBalance);