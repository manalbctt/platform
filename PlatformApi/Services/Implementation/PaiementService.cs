using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlatformApi.Dtos.Response;
using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Services.Implementation
{
    public class PaiementService : IPaiementService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PaiementService(ApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task<Paiement> GetPaiement(int id)
        {
            var paiement = await _context.paiements.FindAsync(id);
            if (paiement == null)
            {
                throw new Exception("Paiement not found");
            }
            return paiement;
        }
        public async Task<List<PaiementResponseDto>> GetPaiementsByVendeurId(int vendeurId)
        {
            var paiements = await _context.paiements
            .Include(p => p.PlanPaiement)
            .Where(p => p.VendeurId == vendeurId)
            .ToListAsync();

            var paiementDtos = paiements.Select(p => new PaiementResponseDto
            {
                id_paiement = p.id_paiement,
                datepaiement = p.datepaiement,
                PaymentMethod = p.PaymentMethod,
                PlanPaiementId = p.PlanPaiementId,
                PlanPaiementLibelle = p.PlanPaiement.libelle_PlanPaimenet
            }).ToList();

            return paiementDtos;
        }
    }
}
