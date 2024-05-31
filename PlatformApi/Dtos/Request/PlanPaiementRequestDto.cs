using PlatformApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlatformApi.Dtos.Request
{
    public class PlanPaiementRequestDto
    {
        public string libelle_PlanPaimenet { get; set; }

        public string description { get; set; }

        public decimal prix { get; set; }

        [JsonIgnore]
        public IList<Paiement> Paiements { get; set; }

    }
}
