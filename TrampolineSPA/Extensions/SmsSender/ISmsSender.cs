using Twilio.Types;

namespace TrampolineSPA.Extensions.SmsSender
{
    public interface ISmsSender
    {
        void SendMessage(PhoneNumber clientNumber, string smsBody);
        void SendSmsInstructions(string service, string phoneNumber, string password);
    }
}
