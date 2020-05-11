using System.Threading.Tasks;
using SignalRTrackingSample.Models;

namespace SignalRTrackingSampleApp.Services
{
    public interface ISignalRService
    {
        Task Connect();

        Task Disconect();

        Task SendLocation(Location location);

        bool IsConnected { get; }
    }
}
