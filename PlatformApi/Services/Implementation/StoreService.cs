using Microsoft.EntityFrameworkCore;
using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Services.Implementation
{
    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext _context;
        public StoreService(ApplicationDbContext context)
        {

            this._context = context;
        }

        public async Task<Store> GetStoreUrl(int id)
        {
            return await this._context.stores.FirstOrDefaultAsync(v => v.id_store == id);
        }
    }
}
