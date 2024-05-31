using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PlatformApi.Dtos.Request;
using PlatformApi.Dtos.Response;
using PlatformApi.Services.Contract;
using Stripe.Checkout;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformApi.Services.Implementation;

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementController : ControllerBase
    {
        private readonly IPaiementService _paiementService;
        private readonly IMapper _mapper;
        private readonly StripeService _stripeService;
        private readonly ILogger<PaiementController> _logger;

        public PaiementController(IPaiementService paiementService, IMapper mapper, StripeService stripeService, ILogger<PaiementController> logger)
        {
            _paiementService = paiementService;
            _mapper = mapper;
            _stripeService = stripeService;
            _logger = logger;
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
                _logger.LogError(ex, $"Error retrieving payments for vendor ID {vendeurId}");
                return StatusCode(500, $"Une erreur s'est produite lors de la récupération des paiements pour le vendeur avec l'ID {vendeurId}: {ex.Message}");
            }
        }
        [HttpPost("create-checkout-session")]
        public async Task<ActionResult> CreateCheckoutSession([FromBody] PlanRequestDto planRequestDto)
        {
            try
            {
                _logger.LogInformation($"Creating checkout session for payment plan ID {planRequestDto.PlanPaiementId}");

                // Récupérer le plan de paiement en fonction de l'ID
                var planPaiement = await _paiementService.GetPlanPaiement(planRequestDto.PlanPaiementId);
                if (planPaiement == null)
                {
                    _logger.LogWarning($"Payment plan ID {planRequestDto.PlanPaiementId} not found");
                    return NotFound($"Le plan de paiement avec l'ID {planRequestDto.PlanPaiementId} n'existe pas.");
                }

                // Utiliser la devise par défaut "MAD" si aucune devise n'est fournie
                var currency = string.IsNullOrEmpty(planRequestDto.Currency) ? "mad" : planRequestDto.Currency;

                // Utiliser le prix du plan de paiement pour créer la session de paiement avec Stripe
                var session = await _stripeService.CreateCheckoutSession(planPaiement.prix, currency);
                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating checkout session");
                return StatusCode(500, $"Une erreur s'est produite lors de la création de la session de paiement : {ex.Message}");
            }
        }




    }
}
