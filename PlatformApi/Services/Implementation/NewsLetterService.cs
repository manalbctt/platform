using PlatformApi.Helper.Data;
using PlatformApi.Models;
using PlatformApi.Services.Contract;

namespace PlatformApi.Services.Implementation
{
    public class NewsLetterService : INewsLetterService

    {
        private readonly ApplicationDbContext _context;

        public NewsLetterService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task updateNewsLetter(NewsLetter newsletter)
        {
            await _context.newsLetters.AddAsync(newsletter);
            await _context.SaveChangesAsync();
        }
    }
}
