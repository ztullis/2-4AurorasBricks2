namespace _2_4AurorasBricks2.Models
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string FromEmail { get; set; }
        public string Password { get; set; }
    }
}
