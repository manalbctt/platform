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
        public async Task<IEnumerable<PaiementResponseDto>> GetPaiementsByVendeurId(int vendeurId)
        {
            // Récupérer les paiements associés au vendeur spécifié
            var paiements = await _context.paiements
                .Where(p => p.VendeurId == vendeurId)
                .ToListAsync();

            // Mapper les paiements vers PaiementResponseDto
            var paiementsDto = _mapper.Map<IEnumerable<PaiementResponseDto>>(paiements);

            return paiementsDto;
        } 
    }
}
