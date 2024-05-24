using PlatformApi.Dtos.Response;
using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IPaiementService
    {
        Task<Paiement> GetPaiement(int id);
        Task<IEnumerable<PaiementResponseDto>> GetPaiementsByVendeurId(int vendeurId);
    }
}
