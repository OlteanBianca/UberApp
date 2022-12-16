using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class DriverHomeVM : NotifyPropertyChangedService
    {
        #region Private Fields

        private readonly DriverPageService _driverPageService;
        private readonly Driver _driver;

        #endregion

        #region Public Properties

        public Driver Driver
        {
            get { return _driver; }
        }

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

        private Command _pickOrderCommand;
        public Command PickOrderCommand
        {
            /// se dechide pagina cu comanda
            /// apasa buton de pick client si se dechide maps cu locatia clientului
            /// revine in aplicatia default apasa client ridicat si dupa se dechide apliatia de maps pt destinatie
            /// revine in aplicatia default si apasa finish order

            get => _pickOrderCommand ??= new(_driverPageService.GoToOrderFlowPage);
        }

        public Command _refreshOrdersCommand;
        public Command RefreshOrdersCommand
        {
            /// se dechide pagina cu comanda
            /// apasa buton de pick client si se dechide maps cu locatia clientului
            /// revine in aplicatia default apasa client ridicat si dupa se dechide apliatia de maps pt destinatie
            /// revine in aplicatia default si apasa finish order

            get => _refreshOrdersCommand ??= new(_driverPageService.RefreshOrders);
        }

        private Command _openLoginPageCommand;
        public Command OpenLoginPageCommand
        {
            get => _openLoginPageCommand ??= new(_driverPageService.OpenLoginPageClicked);
        }

        private Command _profilePageCommand;
        public Command ProfilePageCommand
        {
            get => _profilePageCommand ??= new(_driverPageService.ProfilePageClicked);
        }

        #endregion

        #region Protected Methods

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        #endregion
    }
}