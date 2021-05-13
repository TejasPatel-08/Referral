namespace Referral.DAL.Models
{
    public class BulkSmsOptions
    {
        public string Url { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; }
        public string Type { get; set; }
        public bool IsDefault { get; set; }
    }
}
