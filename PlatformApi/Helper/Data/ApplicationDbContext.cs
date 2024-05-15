using Microsoft.EntityFrameworkCore;
using PlatformApi.Models;

namespace PlatformApi.Helper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendeur>()
                .Property(v => v.date_naissance)
                .HasColumnType("date");

           

            modelBuilder.Entity<VendeurAdmin>()
                .HasKey(sc => new { sc.VendeurId, sc.AdminId });

            modelBuilder.Entity<VendeurAdmin>()
                .HasOne(sc => sc.vendeur)
                .WithMany(s => s.VendeurAdmins)
                .HasForeignKey(sc => sc.VendeurId);

            modelBuilder.Entity<VendeurAdmin>()
                .HasOne(sc => sc.admin)
                .WithMany(c => c.VendeurAdmins)
                .HasForeignKey(sc => sc.AdminId);

           
           
               



            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Paiement> paiements { get; set; }
       
        public DbSet<Store> stores { get; set; }
        public DbSet<Vendeur> vendeurs { get; set; }
        public DbSet<VendeurAdmin> VendeurAdmin { get; set; }
    }
}
