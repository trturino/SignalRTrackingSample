using System;
using System.Threading.Tasks;
using SignalRTrackingSample.Models;

namespace SignalRTrackingSampleApp.Services
{
    public class LocationService : ILocationService
    {
        public async Task<Location> GetLocation()
        {
            try
            {
                var request = new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Best);

                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(request);
                if (location != null)
                    return new Location { Latitude = location.Latitude, Longitude = location.Longitude };

                return null;
            }
            catch (Exception)
            {
                // Unable to get location
                return null;
            }

        }
    }
}
