using PlatformApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlatformApi.Dtos.Request
{
    public class PaiementRequestDto
    {
        [Required]
        public DateTime datepaiement { get; set; }

        [Required]
        public int VendeurId { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public int PlanPaiementId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } 
        public decimal prix { get; set; }

    }
}
