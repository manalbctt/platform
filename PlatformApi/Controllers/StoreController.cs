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
        private readonly IStoreService store;
        public StoreController(IStoreService store)
        {
            this.store = store;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getStoreUrl(int id)
        {
            Store st =await this.store.GetStoreUrl(id);
            if (st == null)
            {
                return NotFound();
            }
            return Ok(st.urlstore);
        }
    }
}
