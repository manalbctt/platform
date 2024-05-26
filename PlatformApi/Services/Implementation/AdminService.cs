using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;
using System.Runtime.InteropServices;

namespace PlatformApi.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {

            this._context = context;
        }

        public async Task<Admin> VerifyLogin(Admin admin)
        {

            var ad = await _context.Admins.FirstOrDefaultAsync(v => v.email_admin == admin.email_admin && v.password==admin.password);
            return ad;
        }

        public async Task<Vendeur> validerVendeur(int idVendeur)
        {
            var vendeur = await _context.vendeurs.FindAsync(idVendeur);
            if (vendeur != null)
            {
                vendeur.verifie_compte = true;
                await this._context.SaveChangesAsync();
            }
            return vendeur;
        }
        public async Task<VendeurAdmin> updateVendeurAdmin(VendeurAdmin VdAd)
        {

             this._context.VendeurAdmin.Add(VdAd);
             await this._context.SaveChangesAsync();
            return VdAd;
           

        }
        public async Task<Vendeur> BannerVendeurAdmin(VendeurAdmin Vd)
        {
            var vendeur = await _context.vendeurs.FindAsync(Vd.VendeurId);
            if (vendeur != null)
            {
                vendeur.block = true;
                await this._context.SaveChangesAsync();
            }
            return vendeur;
        }
    }
}
