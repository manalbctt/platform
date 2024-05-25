using PlatformApi.Models;

namespace PlatformApi.Services.Contract
{
    public interface INewsLetterService
    {
        Task updateNewsLetter(NewsLetter newsletter);
    }
}
