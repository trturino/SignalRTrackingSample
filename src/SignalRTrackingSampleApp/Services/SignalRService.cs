using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRTrackingSampleApp.Events;
using Xamarin.Essentials;

namespace SignalRTrackingSampleApp.Services
{
    public class SignalRService : ISignalRService
    {
        private HubConnection hubConnection;
        private IEventAggregator eventAggregator;


        public bool IsConnected { get; private set; }

        private static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";

        public SignalRService(IEventAggregator eventAggregator)
        {

            hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://{IPAddress}:5000/location")
                .Build();

            this.eventAggregator = eventAggregator;
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
            IsConnected = true;
            hubConnection.On<SignalRTrackingSample.Models.Location>("Location", (location) =>
            {
                this.eventAggregator.Publish(location);
            });
        }

        public async Task Disconect()
        {
            await hubConnection.StopAsync();
            IsConnected = false;
        }

        public async Task SendLocation(SignalRTrackingSample.Models.Location location)
        {
            try
            {
                await hubConnection.InvokeAsync("SendLocation", location);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

    }

    
}
