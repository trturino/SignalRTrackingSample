using System.Threading.Tasks;
using SignalRTrackingSample.Models;

namespace SignalRTrackingSampleApp.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocation();
    }
}
