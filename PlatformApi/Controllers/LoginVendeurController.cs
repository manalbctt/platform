using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Dtos.Request;
using PlatformApi.Helper.Jwt;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginVendeurController : ControllerBase
    {
        private readonly IVendeurService _vendeurService;
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;

        public LoginVendeurController(IVendeurService vendeurService,IMapper mapper,JwtHelper jwtHelper)
        {
            this._mapper= mapper;
            this._vendeurService= vendeurService;
            this._jwtHelper= jwtHelper;
        }


        [HttpPost]
        public async Task<IActionResult> Login(VendeurRequestDto requestDto)
        {
            var vendeur = _mapper.Map<Vendeur>(requestDto);

            var vendeurVerfiy = await this._vendeurService.VerifyLogin(vendeur);
            if(vendeurVerfiy == null)
            {
                return NotFound();
            }

            //generate token and add the id inside claims
            var token = _jwtHelper.GenerateToken(vendeurVerfiy.id_Vendeur.ToString());

            return Ok(new {token});
        }
        [Authorize]
        [HttpGet]
       
        public string hello()
        {
            return "hello world";
        }
    }
}
