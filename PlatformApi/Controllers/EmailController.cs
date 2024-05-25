using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Dtos.Request;
using PlatformApi.Services.Contract;

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public EmailController(IEmailService emailService,IMapper mapper)
        {
            _emailService = emailService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequestDto emailRequest)
        {
            var email = _mapper.Map<EmailRequestDto>(emailRequest);
            if (email == null)
            {
                return BadRequest("Email request is null");
            }

            await _emailService.SendEmailAsync(email.to, email.subject, email.body);
            return Ok("Email sent successfully");
        }

    }
}
