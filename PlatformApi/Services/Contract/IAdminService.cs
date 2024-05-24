using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IAdminService
    {
        Task<Admin> VerifyLogin(Admin admin);
    }
}
