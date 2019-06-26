namespace TrampolineSPA.Extensions.EmailSender
{
    public interface IEmailSender
    {
        void SendEmail(string userEmail, string userTheme, string userMessage);
        void SendInstructions(string service, string email, string password);
    }
}