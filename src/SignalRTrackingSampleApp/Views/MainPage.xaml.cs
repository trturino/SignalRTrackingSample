using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SignalRTrackingSampleApp.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public ICommand NavigateCommand { get; set; }


        public MainPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }
    }
}
