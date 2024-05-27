using Microsoft.AspNetCore.SignalR;

namespace PlatformApi.Hubs
{
    public class userHub :Hub
    {
        public async Task Negotiate(int userId)
        {
            await Clients.All.SendAsync("UserValidated", userId);
        }
    }
}
