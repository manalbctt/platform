using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IPlanPaiementService
    {
        Task<PlanPaiement> GetPlanPaiement(int id);
    }
}
