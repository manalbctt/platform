using PlatformApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlatformApi.Dtos.Response
{
    public class PaiementResponseDto
    {

        public int id_paiement { get; set; }
        public DateTime datepaiement { get; set; }
        [JsonIgnore]
        public Vendeur vendeur { get; set; }

        [ForeignKey("Vendeur")]
        public int VendeurId { get; set; }
        public string PaymentMethod { get; set; }

        [ForeignKey("PlanPaiement")]
        public int PlanPaiementId { get; set; }
        public string PlanPaiementLibelle { get; set; }
        [JsonIgnore]
        public PlanPaiement PlanPaiement { get; set; }
    }
}
