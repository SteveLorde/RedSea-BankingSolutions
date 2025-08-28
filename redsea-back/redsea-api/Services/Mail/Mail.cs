using MailKit.Net.Smtp;
using MimeKit;
using redsea_database.DTOs.Banking;

namespace redsea_api.Services.Mail;

public class Mail(IConfiguration config) : IMail
{
    public async Task<bool> SendMailAsync(MailRequest mailRequest)
    {
        var emailSettings = config.GetSection("Email:Settings");
        var smtpSettings = config.GetSection("Email:Smtp");
        var sender = config["Sender"];

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Sender Name", sender));
        message.To.Add(new MailboxAddress("Recipient Name", mailRequest.To));
        message.Subject = "Test Email from .NET with MailKit";

        var smtpClient = new SmtpClient();
        await smtpClient.ConnectAsync(smtpSettings["Host"], smtpSettings.GetValue<int>("Port"), true);
        await smtpClient.AuthenticateAsync(smtpSettings["Username"], smtpSettings["Password"]);
        var check = smtpClient.SendAsync(message).IsCompletedSuccessfully;

        if (!check)
        {
            check = smtpClient.SendAsync(message).IsCompletedSuccessfully;
        }

        await smtpClient.DisconnectAsync(true);

        return check;
    }
}
