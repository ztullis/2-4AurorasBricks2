namespace _2_4AurorasBricks2.Models
{
    public interface IEmailConfiguration
    {
        string MailServer { get; set; }
        int MailPort { get; set; }
        string SenderName { get; set; }
        string FromEmail { get; set; }
        string Password { get; set; }
    }
}
