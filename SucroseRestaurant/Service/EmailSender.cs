using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Admin.Service
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ankhang897979@gmail.com", "SucRose");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            await client.SendEmailAsync(msg);
        }
    }
}
