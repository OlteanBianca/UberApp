using Syncfusion.XForms.Buttons;
using System;
using System.Threading;
using UberApp.Models;
using UberApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UberApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientHomePage : ContentPage
    {
        public ClientHomePage(Client client)
        {
            Initialization(client);
        }

        private async void Initialization(Client client)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var cts = new CancellationTokenSource();
            var clientLocation = await Geolocation.GetLocationAsync(request, cts.Token);

            InitializeComponent();
            BindingContext = new ClientHomeVM(client);

            if (clientLocation != null)
            {
                var zoomLevel = 13;
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                ClientMap.MoveToRegion(new MapSpan(new Position(clientLocation.Latitude, clientLocation.Longitude), latlongdegrees, latlongdegrees));
            }
        }

        private void ClientMapClicked(object sender, MapClickedEventArgs e)
        {
            ClientHomeVM vm = (ClientHomeVM)BindingContext;
            vm.Pins.Clear();

            Pin pin = new()
            {
                Label = $"{e.Position.Latitude},{e.Position.Longitude}",
                Address = $"{e.Position.Latitude},{e.Position.Longitude}",
                Type = PinType.Generic,
                Position = new Position(e.Position.Latitude, e.Position.Longitude)
            };

            vm.Address = $"{e.Position.Latitude},{e.Position.Longitude}";
            vm.Pins.Add(pin);
        }

        private void ChangeToSatellite(object sender, EventArgs e)
        {
            ClientMap.MapType = MapType.Hybrid;
            ButtonActivated(satellite);
            ButtonDeactivated(streets);
        }

        private void ShowTraffic(object sender, EventArgs e)
        {
            ClientMap.TrafficEnabled = !ClientMap.TrafficEnabled;
            if (ClientMap.TrafficEnabled)
            {
                ButtonActivated(traffic);
            }
            else
            {
                ButtonDeactivated(traffic);
            }
        }

        private void ChangeToDefault(object sender, EventArgs e)
        {
            ClientMap.MapType = MapType.Street;
            ButtonActivated(streets);
            ButtonDeactivated(satellite);
        }

        private void ButtonActivated(SfButton button)
        {
            button.BorderColor = Color.Blue;
            button.BorderWidth = 2;
        }

        private void ButtonDeactivated(SfButton button)
        {
            button.BorderColor = Color.Gray;
            button.BorderWidth = 1;
        }
    }
}