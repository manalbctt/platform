using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Vendeur>> GetAllVendeurs()
        {
            return await _context.vendeurs.ToListAsync();
        }

        public async Task<Vendeur> VerifyLogin(Vendeur vendeur)
        {

            var vd=await _context.vendeurs.FirstOrDefaultAsync(v => v.email_Vendeur == vendeur.email_Vendeur && v.password == vendeur.password && v.verifie_compte==true);
            return vd;
        }

        public async Task<Vendeur> getVendeur(int id)
        {
            return  await _context.vendeurs.FirstOrDefaultAsync(v => v.id_Vendeur == id);
        }

        public async Task UpdateVendeur(int id, Vendeur vendeur) 
        {
            var VendeurModifie = await _context.vendeurs.FirstOrDefaultAsync(p => p.id_Vendeur == id);
            VendeurModifie.nom_Venduer = vendeur.nom_Venduer;
            VendeurModifie.prenom_Vendeur = vendeur.prenom_Vendeur;
            VendeurModifie.email_Vendeur = vendeur.email_Vendeur;
            VendeurModifie.ville = vendeur.ville;
            VendeurModifie.num_telephone = vendeur.num_telephone;

            _context.vendeurs.Update(VendeurModifie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePasswordVendeur(int id, Vendeur vendeur, string NewPassword, string passwordConfirme)
        {
            var VendeurModifie = await _context.vendeurs.FirstOrDefaultAsync(v => v.id_Vendeur == id);
            if (VendeurModifie == null)
            {
                // Vendeur not found
                throw new Exception("Vendeur not found");
            }

            if (VendeurModifie.password != vendeur.password)
            {
                // Return bad request if the current password does not match
                throw new Exception("Current password is incorrect");
            }

            if (NewPassword != passwordConfirme)
            {
                // Return bad request if the new password and confirmation do not match
                throw new Exception("New password and confirmation password do not match");
            }

            VendeurModifie.password = NewPassword; // Update password
            _context.vendeurs.Update(VendeurModifie);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterVendeur(Vendeur vendeur)
            
        {
            vendeur.ville = "oujda";
            await _context.AddAsync(vendeur);
            await _context.SaveChangesAsync();
        }

    }
}
