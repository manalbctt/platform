using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlatformApi.Dtos.Request;
using PlatformApi.Dtos.Response;
using PlatformApi.Helper.Jwt;
using PlatformApi.Models;
using PlatformApi.Services.Contract;
using System.Net;

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
            var token = _jwtHelper.GenerateToken(vendeurVerfiy.id_Vendeur.ToString(),"user");

            //if paid do vendeur // sinon user

            return Ok(new {token});
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(VendeurRegisterRequestDto vendeurRequest)
        {
            var vendeur = _mapper.Map<Vendeur>(vendeurRequest);
            await _vendeurService.RegisterVendeur(vendeur);
            return Ok();
        }
            

        
        [HttpGet]
        public IActionResult get()
        {
            var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                var id = _jwtHelper.GetUserIdFromToken(token);
                if (!string.IsNullOrEmpty(id))
                {
                    // Use the id as needed
                    return Ok(id);
                }
            }

            // Token not found or ID not extracted
            return BadRequest("Invalid token or ID not found");
        }
        [HttpGet("role")]
        public IActionResult getRole()
        {
            var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                var role = _jwtHelper.GetUserRoleFromToken(token);
                if (!string.IsNullOrEmpty(role))
                {
                    // Parse the role into a JSON object
                    var roleObject = new { role = role };
                    var roleJson = JsonConvert.SerializeObject(roleObject);

                    // Return the JSON object
                    return Ok(roleJson);
                    // Use the role as needed
                  //  return Ok(role);
                }
            }

            // Token not found or ID not extracted
            return BadRequest("Invalid token or ID not found");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VendeurResponseDto>> GetVendeur(int id)
        {
            try
            {
                var vendeur = await _vendeurService.getVendeur(id);
                if (vendeur == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<VendeurResponseDto>(vendeur));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving vendeur");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendeur(int id , VendorUpdateDto Newvendeur )
        {
            try
            {
                var vendeur = _mapper.Map<Vendeur>(Newvendeur);
                await _vendeurService.UpdateVendeur(id, vendeur);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Client");
            }
        }

        [HttpPut("updatePassword/{id}")]
        public async Task<ActionResult> UpdatePasswordVendeur(int id, VendeurRequestUpdatePasswordDto newVendeur)
        {
            try
            {
                var vendeur = _mapper.Map<Vendeur>(newVendeur);
                await _vendeurService.UpdatePasswordVendeur(id, vendeur, newVendeur.newPassword, newVendeur.ConfirmPassword);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Vendeur not found")
                {
                    return NotFound("Vendeur not found");
                }
                else if (ex.Message == "Current password is incorrect")
                {
                    return BadRequest("Current password is incorrect");
                }
                else if (ex.Message == "New password and confirmation password do not match")
                {
                    return BadRequest("New password and confirmation password do not match");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating password");
                }
            }
        }

    }
}
