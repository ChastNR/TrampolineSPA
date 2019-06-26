namespace TrampolineSPA.Extensions.EmailSender
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
        public string FromEmail { get; set; }
        public string DisplayName { get; set; }
        public string UserConfirm { get; set; }
    }
}