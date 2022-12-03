using UberApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class DriverPageService
    {
        private readonly DataBaseService _dataBaseService;
        private readonly DriverHomeVM _driverHomeVM;

        public DriverPageService(DriverHomeVM vm)
        {
            _dataBaseService = new();
            _driverHomeVM = vm;
        }

        public void RefreshOrders()
        {
            var requests = _dataBaseService.GetActiveRequests();
            _driverHomeVM.Requests.Clear();
            foreach (var request in requests)
            {
                _driverHomeVM.Requests.Add(request);
            }
        }

        public async void PickOrders()
        {
            if (_driverHomeVM.SelectedItemList != null)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    await Launcher.OpenAsync($"http://maps.apple.com/?q={_driverHomeVM.SelectedItemList.DestinationLocation}");
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // open the maps app directly
                    await Launcher.OpenAsync($"geo:0,0?q={_driverHomeVM.SelectedItemList.DestinationLocation}");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync($"bingmaps:?where={_driverHomeVM.SelectedItemList.DestinationLocation}");
                }
            }
        }
    }
}
