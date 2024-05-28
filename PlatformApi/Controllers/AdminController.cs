using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlatformApi.Dtos.Request;
using PlatformApi.Helper.Jwt;
using PlatformApi.Hubs;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;
        private readonly IHubContext<userHub> _hubContext;


        public AdminController(IAdminService adminService , IMapper mapper, JwtHelper jwtHelper,IHubContext<userHub> hubContext)
        {
            this._adminService = adminService;
            this._mapper = mapper;
            this._jwtHelper= jwtHelper;
            this._hubContext= hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminRequestDto requestDto)
        {
            var admin = _mapper.Map<Admin>(requestDto);

            var adminVerfiy = await this._adminService.VerifyLogin(admin);
            if (adminVerfiy == null)
            {
                return NotFound(); 
            }

            //generate token and add the id inside claims
            var token = _jwtHelper.GenerateToken(adminVerfiy.id_admin.ToString(),"admin");

            return Ok(new { token });
        }

        [HttpPost("validate")]
        public async Task<IActionResult> validerVendeur(AdminVendeurRequestDto requestdto)
        {
            // this method valider le vendeur (change le status dans vendeur table et inserer une ligne dans la table VendeurAdmin)

            var adminVendeur = _mapper.Map<VendeurAdmin>(requestdto);
            await this._adminService.validerVendeur(adminVendeur.VendeurId);

            await this._adminService.updateVendeurAdmin(adminVendeur);


            await _hubContext.Clients.All.SendAsync("UserValidated", adminVendeur.VendeurId);
            


               
            return NoContent();

        }
        [HttpPost("Banned")]
        public async Task<IActionResult> bannerVendeur(AdminVendeurRequestDto requestdto)
        {
            var adminVendeur = _mapper.Map<VendeurAdmin>(requestdto);
            await this._adminService.BannerVendeurAdmin(adminVendeur);
            await this._adminService.updateVendeurAdmin(adminVendeur);
            return NoContent();

        }


    }
}
