// Services/SmtpEmailSender.cs
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace UserManagement02.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public SmtpEmailSender(IConfiguration config)
        {
            _config = config;
        }
        
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var host = _config["Smtp:Host"];
            var port = int.Parse(_config["Smtp:Port"]!);
            var user = _config["Smtp:User"];
            var pass = _config["Smtp:Pass"];
            var from = _config["Smtp:From"];
            ;

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = true
            };

            var msg = new MailMessage(from, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };
            return client.SendMailAsync(msg);
        }
    }
}
