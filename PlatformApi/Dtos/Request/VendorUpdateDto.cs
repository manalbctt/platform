namespace PlatformApi.Dtos.Request
{
    public class VendorUpdateDto
    {
        public string nom_Venduer { get; set; }
        public string prenom_Vendeur { get; set; }
        public string email_Vendeur { get; set; }
        public int num_telephone { get; set; }
        public string ville { get; set; }
    }
}
