using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformApi.Models
{
    public class VendeurAdmin
    {

       public Admin admin { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
       public Vendeur vendeur { get; set; }
        [ForeignKey("vendeur")]

        public int VendeurId { get; set; }

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
        public string Action { get; set; }


    }
}
