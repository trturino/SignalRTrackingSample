using System;
using System.ComponentModel;
using SignalRTrackingSample.Models;
using SignalRTrackingSampleApp.Events;
using SignalRTrackingSampleApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SignalRTrackingSampleApp.ViewModels
{
    public class ViewLocationViewModel : INotifyPropertyChanged
    {
        private ISignalRService signalRService;
        private IDisposable subscription;

        public ViewLocationViewModel(
            IEventAggregator eventAggregator,
            ISignalRService signalRService
            )
        {
            this.subscription = eventAggregator.Subscribe<Location>(OnLocationReceived);
            this.signalRService = signalRService;
            this.signalRService.Connect();
        }

        public Pin UserLocation { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnLocationReceived(Location location)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                UserLocation = new Pin { Position = new Position(location.Latitude, location.Longitude), Label = "User" };

                OnPropertyChanged(nameof(UserLocation));
            });
        }
    }
}
