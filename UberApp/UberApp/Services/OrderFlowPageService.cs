using System;
using System.Threading;
using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class OrderFlowPageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly OrderFlowVM _orderFlowVM;

        #endregion

        #region Constructors

        public OrderFlowPageService(OrderFlowVM orderFlowVM)
        {
            _dataBaseService = new();
            _orderFlowVM = orderFlowVM;
        }

        #endregion

        #region Public Methods

        public async void GoToClientClicked()
        {
            Request request = _orderFlowVM.Request;
            if (request == null) return;

            if (request != null)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    await Launcher.OpenAsync($"http://maps.apple.com/?q={request.DestinationName}");
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

                    await Map.OpenAsync(new Location(request.ClientLocationLatitude, request.ClientLocationLongitude), options);

                    // open the maps app directly
                    // await Launcher.OpenAsync($"geo:0,0?q={request.DestinationName}");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync($"bingmaps:?where={request.DestinationName}");
                }
            }
        }

        public async void ClientPickedClicked()
        {
            Request request = _orderFlowVM.Request;
            if (request == null) return;

            if (Device.RuntimePlatform == Device.Android)
            {
                await Map.OpenAsync(new Location(request.ClientLocationLatitude, request.ClientLocationLongitude));
            }
            _orderFlowVM.ClientPicked = true;
        }

        public async void GoToDestinationClicked()
        {
            Request request = _orderFlowVM.Request;
            if (request == null) return;

            if (Device.RuntimePlatform == Device.Android)
            {
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

                await Map.OpenAsync(new Location(request.DestinationLatitude, request.DestinationLongitude), options);
            }
        }

        public async void RequestFinishedClicked()
        {
            Request request = _orderFlowVM.Request;
            if (request == null) return;

            if (Device.RuntimePlatform == Device.Android)
            {
                var locationRequest = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var cts = new CancellationTokenSource();
                var clientLocation = await Geolocation.GetLocationAsync(locationRequest, cts.Token);

                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

                await Map.OpenAsync(new Location(clientLocation.Latitude, clientLocation.Longitude), options);
            }

            request.Finished = true;
            _dataBaseService.UpdateRequest(request);

            DriverHomePage driverHomePage = new(request.Driver);
            Application.Current.MainPage = driverHomePage;
        }

        #endregion
    }
}
