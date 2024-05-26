using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Dtos.Response;
using PlatformApi.Services.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendeurController : ControllerBase

    {
        private readonly IVendeurService _vendeurService;
        private readonly IMapper _mapper;

        public VendeurController(IVendeurService VendeurService, IMapper mapper)
        {
            _vendeurService = VendeurService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendeurResponseDto>>> GetAllVendeurs()
        {
            try
            {
                var vendeurs = await _vendeurService.GetAllVendeurs();
                var vendeurDtos = _mapper.Map<IEnumerable<VendeurResponseDto>>(vendeurs);
                return Ok(vendeurDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving vendeurs");
            }
        }
        
        

    }
}
