using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("gkpe24@gmail.com", "test"),
                EnableSsl = true,
            };
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("gkpe24@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(to);

            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
                _logger.LogInformation("Correo enviado con éxito.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar correo: {ex.Message}");
            }
        }
    }
}
