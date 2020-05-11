using System.Linq;
using SignalRTrackingSampleApp.ViewModels;
using Xamarin.Forms.Maps;

namespace SignalRTrackingSampleApp.Views
{
    public partial class ViewLocationPage
    {
        public ViewLocationPage()
        {
            InitializeComponent();

            BindingContext = new ViewLocationViewModel(App.EventAggregator, App.SignalRService);

            ((ViewLocationViewModel)BindingContext).PropertyChanged += ViewLocationPage_PropertyChanged;
        }

        private void ViewLocationPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var pin = ((ViewLocationViewModel)BindingContext).UserLocation;
            if (pin != null)
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(1)));
                map.Pins.Clear();
                map.Pins.Add(pin);
            }
        }
    }
}
