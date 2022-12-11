using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;

namespace UberApp.ViewModels
{
    public class OrderFlowVM : NotifyPropertyChangedService
    {
        #region Private Fields

        private readonly OrderFlowPageService _orderFlowPageService;
        private Driver _driver;
        private Request _request;
        private bool _requestFinished = false;
        private bool _clientPicked = false;

        #endregion

        #region Public Properties

        public Driver Driver
        {
            get => _driver;
            set
            {
                _driver = value;
                OnPropertyChanged();
            }
        }

        public Request Request
        {
            get => _request;
            set
            {
                _request = value;
                OnPropertyChanged();
            }
        }

        public bool ClientPicked
        {
            get => _clientPicked;
            set
            {
                _clientPicked = value;
                OnPropertyChanged();
            }
        }

        public bool RequestFinished
        {
            get => _requestFinished;
            set
            {
                _requestFinished = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public OrderFlowVM(Request request)
        {
            Driver = request.Driver;
            Request = request;
            _orderFlowPageService = new(this);
        }

        #endregion

        #region Commands

        private Command _goToClientCommand;
        public Command GoToClientCommand
        {
            get => _goToClientCommand ??= new(_orderFlowPageService.GoToClientClicked);
        }

        private Command _clientPickedCommand;
        public Command ClientPickedCommand
        {
            get => _clientPickedCommand ??= new(_orderFlowPageService.ClientPickedClicked);
        }

        private Command _goToDestinationCommand;
        public Command GoToDestinationCommand
        {
            get => _goToDestinationCommand ??= new(_orderFlowPageService.GoToDestinationClicked);
        }

        private Command _requestFinishedCommand;
        public Command RequestFinishedCommand
        {
            get => _requestFinishedCommand ??= new(_orderFlowPageService.RequestFinishedClicked);
        }

        #endregion
    }
}
