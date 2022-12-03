using System.Collections.ObjectModel;
using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;

namespace UberApp.ViewModels
{
    public class DriverHomeVM : NotifyPropertyChangedService
    {
        #region Private Fields

        private readonly DriverPageService _driverPageService;
        private readonly Driver _driver;

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
            _driverPageService.RefreshOrders();
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

        private Command _openLoginPageCommand;
        public Command OpenLoginPageCommand
        {
            get
            {
                _openLoginPageCommand ??= new(_driverPageService.OpenLoginPageClicked);
                return _openLoginPageCommand;
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