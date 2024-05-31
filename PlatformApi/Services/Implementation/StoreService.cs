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
            _context = context;
        }

        public async Task<bool> CreateStoreAsync(Store store)
        {
            if (!IsLogoValid(store.UrlLogo))
            {
                return false;
            }

            _context.Add(store);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsLogoValid(string urlLogo)
        {
            return urlLogo.EndsWith(".png", StringComparison.OrdinalIgnoreCase);

        }

        public async Task<Store> GetStoreUrl(int id)
        {
            return await this._context.stores.FirstOrDefaultAsync(v => v.id_store == id);

        }
    }
}
