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
            MailAddress from = new MailAddress(EmailSettings.FromEmail, EmailSettings.DisplayName);
            MailAddress to = new MailAddress(mailTo);
            MailMessage m = new MailMessage(from, to)
            {
                Subject = mailSubject,
                Body = mailBody
            };

            SmtpClient smtp = new SmtpClient(EmailSettings.PrimaryDomain, EmailSettings.PrimaryPort)
            {
                Credentials = new NetworkCredential(EmailSettings.UsernameEmail, EmailSettings.UsernamePassword),
                EnableSsl = true
            };

            await smtp.SendMailAsync(m);
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