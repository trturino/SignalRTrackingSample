using SignalRTrackingSampleApp.Events;
using SignalRTrackingSampleApp.Services;
using SignalRTrackingSampleApp.Views;
using Xamarin.Forms;

namespace SignalRTrackingSampleApp
{
    public partial class App : Application
    {
        public static IEventAggregator EventAggregator { get; private set; }
        public static ISignalRService SignalRService { get; private set; }

        public App()
        {
            InitializeComponent();

            EventAggregator = new EventAggregator();
            SignalRService = new SignalRService(App.EventAggregator);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
