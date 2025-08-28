namespace redsea_database.DTOs.Invest;

public record InvestRequest(
    string clientId,
    string stockId,
    decimal amount
    );