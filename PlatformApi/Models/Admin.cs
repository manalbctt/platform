using System.ComponentModel.DataAnnotations;

namespace PlatformApi.Models
{
    public class Admin
    {
        [Key]
        public int id_admin { get; set;}
        public string nom_admin { get; set;}
        public string prenom_admin { get; set;}
        public DateTime date_naissance { get; set;}
        public string email_admin { get; set;}
        public string num_telephone { get; set;}
        public string password { get; set;}
        public string ville { get; set; }

        public IList<VendeurAdmin> VendeurAdmins { get; set; }
    }
}
