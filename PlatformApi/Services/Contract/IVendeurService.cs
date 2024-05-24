using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IVendeurService
    {
        Task<Vendeur> VerifyLogin(Vendeur vendeur);
        Task<IEnumerable<Vendeur>> GetAllVendeurs();
        Task<Vendeur> getVendeur(int id);
        Task UpdateVendeur(int id, Vendeur vendeur);
        Task UpdatePasswordVendeur(int id, Vendeur vendeur, string NewPassword, string passwordConfirme);
        Task RegisterVendeur(Vendeur vendeur);
    }
}
