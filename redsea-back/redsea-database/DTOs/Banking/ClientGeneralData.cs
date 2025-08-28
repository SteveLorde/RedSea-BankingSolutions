namespace redsea_database.DTOs.Banking;

public record ClientGeneralData(
    string IsActive,
    decimal AccountBalance,
    decimal CertificatesBalance,
    decimal LoansBalance
) : TDTO;