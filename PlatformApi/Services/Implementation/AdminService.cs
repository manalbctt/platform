using Microsoft.EntityFrameworkCore;
using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

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
    }
}
