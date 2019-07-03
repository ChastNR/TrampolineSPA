using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrampolineSPA.Extensions.EmailSender;

namespace TrampolineSPA.Extensions.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings EmailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string mailTo, string mailSubject, string mailBody)
        {
            MailMessage m = new MailMessage(
                new MailAddress(EmailSettings.FromEmail, EmailSettings.DisplayName),
                new MailAddress(mailTo))
            {
                Subject = mailSubject,
                Body = mailBody
            };

            await new SmtpClient(EmailSettings.PrimaryDomain, EmailSettings.PrimaryPort)
            {
                Credentials = new NetworkCredential(EmailSettings.UsernameEmail, EmailSettings.UsernamePassword),
                EnableSsl = true
            }.SendMailAsync(m);
        }

        public void SendEmail(string userEmail, string userTheme, string userMessage)
        {
            SendEmailAsync(userEmail, userTheme, userMessage).GetAwaiter();
        }

        public void SendInstructions(string service, string email, string password)
        {
            string theme = "Инструкция по проверке вашего аккаунта";
            string message = "Привет! Спасибо, что приобрели услугу: " + service + "!" +
                             "\nЧтобы активировать услугу - войдите Ваш аккаунт:\n" + EmailSettings.UserConfirm +
                             "\nВаш персональный пароль: " + password;

            SendEmailAsync(email, theme, message).GetAwaiter();
        }
    }
}