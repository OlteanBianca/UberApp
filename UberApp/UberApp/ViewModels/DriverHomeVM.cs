using System.Collections.ObjectModel;
using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;

namespace UberApp.ViewModels
{
    public class DriverHomeVM : NotifyPropertyChangedService
    {
        #region Private Fields

        private DriverPageService _driverPageService;
        private Driver _driver;

        #endregion

        #region Public Properties

        public ObservableCollection<Request> Requests { get; set; }

        #endregion
     
        #region Constructors
        public DriverHomeVM(Driver driver)
        {
            _driver = driver;
            Requests = new ObservableCollection<Request>();
            _driverPageService = new(this);

            //Request request = new()
            //{
            //    RequestId=1,
            //    UserId=1,
            //    DriverId=1,
            //    ClientLocationLatitudine=1,
            //    ClientLocationLongitudine=1,
            //    DestinationLocation = "Colegiul national andrei saguna"
            //};
            //Request request2 = new()
            //{
            //    RequestId = 1,
            //    UserId = 1,
            //    DriverId = 1,
            //    ClientLocationLatitudine = 1,
            //    ClientLocationLongitudine = 1,
            //    DestinationLocation = "Colegiul national doctor ioan mesota"
            //};
            //this.Requests.Add(request);
            //this.Requests.Add(request2);
        }
        #endregion

        #region Commands

        private Request _SelectedItemList;
        public Request SelectedItemList
        {
            get
            {

                return _SelectedItemList;
            }
            set
            {
                _SelectedItemList = value;
                OnPropertyChanged();
            }
        }

        private Command _pickOrderCommand;
        public Command PickOrderCommand
        {
            get
            {
                /// se dechide pagina cu comanda
                /// apasa buton de pick client si se dechide maps cu locatia clientului
                /// revine in aplicatia default apasa client ridicat si dupa se dechide apliatia de maps pt destinatie
                /// revine in aplicatia default si apasa finish order

                _pickOrderCommand ??= new(_driverPageService.PickOrders);
                return _pickOrderCommand;
            }
        }

        public Command _refreshOrdersCommand;
        public Command RefreshOrdersCommand
        {
            get
            {
                /// se dechide pagina cu comanda
                /// apasa buton de pick client si se dechide maps cu locatia clientului
                /// revine in aplicatia default apasa client ridicat si dupa se dechide apliatia de maps pt destinatie
                /// revine in aplicatia default si apasa finish order

                _refreshOrdersCommand ??= new(_driverPageService.RefreshOrders);
                return _refreshOrdersCommand;
            }
        }

        #endregion
    }
}
//geo: latitude,longitude? z = zoom


//if (Device.RuntimePlatform == Device.iOS)
//{
//    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
//    await Launcher.OpenAsync("http://maps.apple.com/?daddr=San+Francisco,+CA&saddr=cupertino");
//}
//else if (Device.RuntimePlatform == Device.Android)
//{
//    // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
//    await Launcher.OpenAsync("http://maps.google.com/?daddr=San+Francisco,+CA&saddr=Mountain+View");
//}
//else if (Device.RuntimePlatform == Device.UWP)
//{
//    await Launcher.OpenAsync("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052");
//}


//if (Device.RuntimePlatform == Device.iOS)
//{
//    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
//    await Launcher.OpenAsync("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA");
//}
//else if (Device.RuntimePlatform == Device.Android)
//{
//    // open the maps app directly
//    await Launcher.OpenAsync("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA");
//}
//else if (Device.RuntimePlatform == Device.UWP)
//{
//    await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
//}