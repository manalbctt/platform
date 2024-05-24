using AutoMapper;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;

        public AdminController(IAdminService adminService , IMapper mapper, JwtHelper jwtHelper)
        {
            this._adminService = adminService;
            this._mapper = mapper;
            this._jwtHelper= jwtHelper;
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
            var token = _jwtHelper.GenerateToken(admin.id_admin.ToString(),"admin");

            return Ok(new { token });
        }
    }
}
