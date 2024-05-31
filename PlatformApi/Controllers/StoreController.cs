using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Models;
using PlatformApi.Services.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PlatformApi.Dtos.Request;
using AutoMapper;

namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(StoreRequestDto storerequestdto)
        {
            var store = _mapper.Map<Store>(storerequestdto);

            if (store == null)
            {
                return BadRequest("Store is null");
            }

            bool isCreated = await _storeService.CreateStoreAsync(store);
            if (!isCreated)
            {
                return BadRequest("Invalid logo format. Only .png files are allowed.");
            }

            return Ok("Store created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getStoreUrl(int id)
        {
            Store st = await this._storeService.GetStoreUrl(id);
            if (st == null)
            {
                return NotFound();
            }
            return Ok(st.urlstore);
        }
        [HttpGet("vendor/{id}")]
        public async Task<IActionResult> getStoreUrlByVendor(int id)
        {
            Store st = await this._storeService.GetStoreUrlbyVendor(id);
            if (st == null)
            {
                return NotFound();
            }
            return Ok(st.urlstore);
        }
    }
}
