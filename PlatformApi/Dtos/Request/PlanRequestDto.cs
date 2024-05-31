using System.ComponentModel.DataAnnotations;

namespace PlatformApi.Dtos.Request
{
    public class PlanRequestDto
    {
        [Required]
        public int PlanPaiementId { get; set; }

        [Required]
        public string Currency { get; set; } = "mad";
    }
}
