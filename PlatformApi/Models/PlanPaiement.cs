using System.ComponentModel.DataAnnotations;

namespace PlatformApi.Models
{
    public class PlanPaiement
    {
        [Key]
        public int id_PlanPaiement { get; set; }
        public string libelle_PlanPaimenet { get; set; }

        public string description { get; set; }

        public decimal prix { get; set; }


        public IList<Paiement> Paiements { get; set; }









    }
}
