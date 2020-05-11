using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SignalRTrackingSampleApp.Services;
using Xamarin.Forms;

namespace SignalRTrackingSampleApp.ViewModels
{
    public class SendLocationViewModel
    {
        private ISignalRService signalRService;
        private ILocationService locationService;

        public SendLocationViewModel(
            ISignalRService signalRservice,
            ILocationService locationService
            )
        {
            this.signalRService = signalRservice;
            this.locationService = locationService;
            StartSendingLocation = new Command(OnStartSendingLocation);
        }

        public ICommand StartSendingLocation { get; }

        public async void OnStartSendingLocation()
        {
            if (!signalRService.IsConnected)
                await signalRService.Connect();

            Observable
                .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
                .Subscribe(async _ => await SendLocation());
        }

        private async Task SendLocation()
        {
            var location = await locationService.GetLocation();
            if (location != null)
                await signalRService.SendLocation(location);
        }
    }
}
