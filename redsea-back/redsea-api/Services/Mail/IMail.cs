using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Mail;

public interface IMail
{
    public Task<bool> SendMailAsync(MailRequest mailRequest);
}