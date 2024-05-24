using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformApi.Dtos.Response;
using PlatformApi.Helper.Data;
using PlatformApi.Services.Contract;
using PlatformApi.Services.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementController : ControllerBase
    {
        private readonly IPaiementService _paiementService;
        private readonly IMapper _mapper;

        public PaiementController(IPaiementService PaiementService, IMapper mapper)
        {
            _paiementService = PaiementService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PaiementResponseDto>> GetPaiement(int id)
        {

            var paiement = await _paiementService.GetPaiement(id);
            if (paiement == null)
            {
                return NotFound();
            }
            var paiementDto = _mapper.Map<PaiementResponseDto>(paiement);
            return Ok(paiementDto);
        }
        [HttpGet("vendeur/{vendeurId}")]
        public async Task<ActionResult<IEnumerable<PaiementResponseDto>>> GetPaiementsByVendeurId(int vendeurId)
        {
            try
            {
                var paiements = await _paiementService.GetPaiementsByVendeurId(vendeurId);
                if (paiements == null || !paiements.Any())
                {
                    return NotFound();
                }
                return Ok(paiements);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Une erreur s'est produite lors de la récupération des paiements pour le vendeur avec l'ID {vendeurId}: {ex.Message}");
            }
        }

    }
}
