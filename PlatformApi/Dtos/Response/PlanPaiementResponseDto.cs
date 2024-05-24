using PlatformApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlatformApi.Dtos.Response
{
    public class PlanPaiementResponseDto
    {
        public int id_PlanPaiement { get; set; }
        public string libelle_PlanPaimenet { get; set; }

        public string description { get; set; }

        public float prix { get; set; }

        [JsonIgnore]
        public IList<Paiement> Paiements { get; set; }

    }
}
