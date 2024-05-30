using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IStoreService
    {
        Task<bool> CreateStoreAsync(Store store);
        bool IsLogoValid(string urlLogo);
    }
}
