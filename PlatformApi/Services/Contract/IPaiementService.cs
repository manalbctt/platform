using PlatformApi.Dtos.Response;
using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IPaiementService
    {
        Task<Paiement> GetPaiement(int id);
        Task<List<PaiementResponseDto>> GetPaiementsByVendeurId(int vendeurId);
        Task <PlanPaiement>GetPlanPaiement(int planPaiementId);
    }
}
