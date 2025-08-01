namespace redsea_database.DTOs.Banking;

public record MailRequest(
    string To,
    string Subject,
    string Body);