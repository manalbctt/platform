using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformApi.Models;
using PlatformApi.Services.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;



namespace PlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] Store store)
        {
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
    }
}
