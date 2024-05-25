using System.ComponentModel.DataAnnotations;

namespace PlatformApi.Models
{
    public class NewsLetter
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime SubscriptionDate { get; set; } = DateTime.UtcNow; // Default value is set to current UTC time
        public bool SubscriptionStatus { get; set; } = true; // Default value is set to true
    }
}
