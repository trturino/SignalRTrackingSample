using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRTrackingSample.Models;

namespace SignalRTrackingSample.Hubs
{
    public class LocationHub : Hub
    {
        public async Task SendLocation(Location location)
        {
            await Clients.All.SendAsync("Location", location);
        }
    }
}
