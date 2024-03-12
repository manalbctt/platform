using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformApi.Models
{
    public class Store
    {
        [Key]
        public int id_store { get; set; }
        public DateTime dateCreation { get; set; }
        public string nom_store { get; set; }
        public string description { get; set; }
        public string urlstore {  get; set; }
        public Vendeur Vendeur { get; set; }
        [ForeignKey("Vendeur")]

        public int VendeurId { get; set; }

    }
}
