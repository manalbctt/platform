using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IVendeurService
    {
        Task<Vendeur> VerifyLogin(Vendeur vendeur);
    }
}
