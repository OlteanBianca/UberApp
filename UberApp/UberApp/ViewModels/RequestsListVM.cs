using System.Collections.ObjectModel;
using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;

namespace UberApp.ViewModels
{
    public class RequestsListVM
    {
        #region Private Fields

        private Client _client;
        private Driver _driver;
        private readonly RequestsListPageService _requestsListPageService;

        #endregion

        #region Public Properties

        public Client Client { get { return _client; } }
        public Driver Driver { get { return _driver; } }

        public ObservableCollection<Request> Requests { get; set; }

        #endregion

        #region Private Methods

        private void Initialization(object value)
        {
            switch (value)
            {
                case Models.Client:
                    {
                        _client = (Client)value;
                        return;
                    }
                case Models.Driver:
                    {
                        _driver = (Driver)value;
                        break;
                    }
            }
        }

        #endregion

        #region Constructors

        public RequestsListVM(object value)
        {
            Initialization(value);
            Requests = new ObservableCollection<Request>();
            _requestsListPageService = new(this);
            _requestsListPageService.RefreshOrders();
        }

        #endregion

        #region Commands

        private Command _goBackToProfilePageCommand;
        public Command GoBackToProfilePageCommand
        {
            get => _goBackToProfilePageCommand ??= new(_requestsListPageService.GoBackToProfilePageClicked);
        }

        private Command _continueRequestCommand;
        public Command ContinueRequestCommand
        {
            get => _continueRequestCommand ??= new(_requestsListPageService.ContinueRequestClicked);
        }

        #endregion
    }
}
