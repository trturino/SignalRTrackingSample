using SignalRTrackingSampleApp.Services;
using SignalRTrackingSampleApp.ViewModels;
using Xamarin.Forms;

namespace SignalRTrackingSampleApp.Views
{
    public partial class SendLocationPage
    {
        public SendLocationPage()
        {
            InitializeComponent();

            BindingContext = new SendLocationViewModel(
                new SignalRService(App.EventAggregator),
                new LocationService());
        }
    }
}
