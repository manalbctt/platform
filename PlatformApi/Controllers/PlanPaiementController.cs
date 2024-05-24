using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Dtos.Response;
using PlatformApi.Services.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanPaiementController : ControllerBase
    {
        private readonly IPlanPaiementService _planpaiementService;
        private readonly IMapper _mapper;

        public PlanPaiementController(IPlanPaiementService PlanPaiementService, IMapper mapper)
        {
            _planpaiementService = PlanPaiementService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanPaiementResponseDto>> GetPlanPaiement(int id)
        {

            var planpaiement = await _planpaiementService.GetPlanPaiement(id);
            if (planpaiement == null)
            {
                return NotFound();
            }
            var planpaiementDto = _mapper.Map<PlanPaiementResponseDto>(planpaiement);
            return Ok(planpaiementDto);
        }
    }
}
