using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IAdminService
    {
        Task<Admin> VerifyLogin(Admin admin);
        Task<Vendeur> validerVendeur(int idVendeur);
         Task<VendeurAdmin> updateVendeurAdmin(VendeurAdmin VdAd);
        Task<Vendeur> BannerVendeurAdmin(VendeurAdmin Vd);
    }
}
