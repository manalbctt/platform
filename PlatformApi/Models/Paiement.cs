using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformApi.Models
{
    public class Paiement
    {
        [Key]
        public int id_paiement { get; set; }
        public DateTime datepaiement { get; set; }
        public Vendeur vendeur { get; set; }

        [ForeignKey("Vendeur")]
        public int VendeurId { get; set; }
        public string PaymentMethod { get; set; }

        [ForeignKey("PlanPaiement")]
        public int PlanPaiementId { get; set; }

        public PlanPaiement PlanPaiement { get; set; }






    }
}
