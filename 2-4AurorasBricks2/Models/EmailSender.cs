using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace _2_4AurorasBricks2.Models
{
    public interface ISenderEmail
    {
        Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false);
    }

    public class EmailSender : ISenderEmail
    {
        private readonly IEmailConfiguration _emailConfig;

        public EmailSender(IEmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false)
        {
            var client = new SmtpClient(_emailConfig.MailServer, _emailConfig.MailPort)
            {
                Credentials = new NetworkCredential(_emailConfig.FromEmail, _emailConfig.Password),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage(_emailConfig.FromEmail, ToEmail, Subject, Body)
            {
                IsBodyHtml = IsBodyHtml
            };

            return client.SendMailAsync(mailMessage);
        }
    }
}
