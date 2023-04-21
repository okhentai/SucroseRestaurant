using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Admin.Service
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = "YOUR_API_SENDGRID_KEY";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("YOUR_EMAIL_SENDER", "YOUR_NAME");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            await client.SendEmailAsync(msg);
        }
    }
}
