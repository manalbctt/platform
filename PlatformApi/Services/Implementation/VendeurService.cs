using Microsoft.EntityFrameworkCore;
using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Services.Implementation
{
    public class VendeurService : IVendeurService
    {
        private readonly ApplicationDbContext _context;
        public VendeurService(ApplicationDbContext context)
        {
            
            this._context= context; 
        }

        public async Task<Vendeur> VerifyLogin(Vendeur vendeur)
        {

            var vd=await _context.vendeurs.FirstOrDefaultAsync(v => v.email_Vendeur == vendeur.email_Vendeur && v.password == vendeur.password);
            return vd;
        }
    }
}
