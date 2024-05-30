using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface IStoreService
    {
        Task<Store> GetStoreUrl(int id);
    }
}
