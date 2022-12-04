using UberApp.Models;
using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Services
{
    [Preserve(AllMembers = true)]
    public class DriverPageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly DriverHomeVM _driverHomeVM;

        #endregion

        #region Constructors

        public DriverPageService(DriverHomeVM vm)
        {
            _dataBaseService = new();
            _driverHomeVM = vm;
        }

        #endregion

        #region Public Methods

        public void RefreshOrders()
        {
            var requests = _dataBaseService.GetActiveRequests();
            _driverHomeVM.Requests.Clear();
            foreach (var request in requests)
            {
                _driverHomeVM.Requests.Add(request);
            }
        }

        public async void PickOrders(object obj)
        {
            if (obj is not Request request) return;

            if (request != null)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    await Launcher.OpenAsync($"http://maps.apple.com/?q={request.DestinationLocation}");
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // open the maps app directly
                    await Launcher.OpenAsync($"geo:0,0?q={request.DestinationLocation}");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync($"bingmaps:?where={request.DestinationLocation}");
                }
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
