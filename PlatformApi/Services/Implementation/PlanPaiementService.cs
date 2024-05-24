using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;
using System.Reflection.Metadata.Ecma335;

namespace PlatformApi.Services.Implementation
{
    public class PlanPaiementService : IPlanPaiementService
    {
        private readonly ApplicationDbContext _context;
        public PlanPaiementService(ApplicationDbContext context)
        {

            this._context = context;
        }
        public async Task<PlanPaiement> GetPlanPaiement(int id)
        {
            var plan = await _context.PlanPaiement.FindAsync(id);
            if (plan == null)
            {
                throw new Exception("PlanPaiement not found");
            }
            return plan;
        }
        
    }
}
