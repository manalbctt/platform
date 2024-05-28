using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Dtos.Request;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INewsLetterService newsLetterService;

        public NewsLetterController(IMapper mapper , INewsLetterService newletter)
        {
            this._mapper = mapper;
            this.newsLetterService = newletter;
            
        }
        [HttpPost]
        public async Task<IActionResult> addEmail(NewsLetterRequestDto requestDto)
        {
            var NewsLetter = _mapper.Map<NewsLetter>(requestDto);
            if (NewsLetter == null)
            {
                return NotFound();
            }
            //add newsletter using a service

            await this.newsLetterService.updateNewsLetter(NewsLetter);
            return CreatedAtAction(nameof(addEmail), new { id = NewsLetter.Id }, NewsLetter);

        }
    }
}
