using System;
using System.Linq;
using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace UberApp.Services
{
    [Preserve(AllMembers = true)]
    public class ClientPageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly ClientHomeVM _clientHomeVM;

        #endregion

        #region Constructors

        public ClientPageService(ClientHomeVM vm)
        {
            _dataBaseService = new();
            _clientHomeVM = vm;
        }

        #endregion

        #region Public Methods

        public async void CallCab()
        {
            if (_clientHomeVM.Pins.Count != 0)
            {
                _clientHomeVM.Pins.RemoveAt(0);
            }

            var clientLocation = await Geolocation.GetLocationAsync();

            var locations = await Geocoding.GetLocationsAsync(_clientHomeVM.Address);

            var location = locations?.FirstOrDefault();

            if (location != null)
            {
                Pin pin = new()
                {
                    Label = _clientHomeVM.Address,
                    Address = _clientHomeVM.Address,
                    Type = PinType.Generic,
                    Position = new Position(location.Latitude, location.Longitude)
                };

                _clientHomeVM.Pins.Add(pin);
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                Console.WriteLine($"Address is: {_clientHomeVM.Address}");

                Request request = new()
                {
                    ClientId = 1,
                    DriverId = -1,
                    ClientLocationLatitudine = clientLocation.Latitude,
                    ClientLocationLongitudine = clientLocation.Longitude,
                    DestinationLocation = _clientHomeVM.Address
                };

                _dataBaseService.AddRequest(request);
            }
        }

        public void OpenLoginPageClicked()
        {
            LoginPage loginPage = new();
            Application.Current.MainPage = loginPage;
        }

        #endregion
    }
}