namespace redsea_database.DTOs.Banking;

public record ClientGeneralData(
    string IsActive,
    float AccountBalance,
    float CertificatesBalance,
    float LoansBalance
    ) : TDTO;