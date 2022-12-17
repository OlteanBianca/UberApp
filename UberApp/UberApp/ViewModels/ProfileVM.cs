using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ProfileVM : NotifyPropertyChangedService
    {
        #region Private Fields

        private bool _isDriver;
        private Client _client;
        private Driver _driver;
        private readonly ProfilePageService _profilePageService;

        #endregion

        #region Public Properties

        public bool IsDriver
        {
            get => _isDriver;
            set
            {
                _isDriver = value;
                OnPropertyChanged();
            }
        }

        public Client Client { get => _client; }

        public Driver Driver { get => _driver; }

        #endregion

        #region Private Methods

        private void Initialization(object value)
        {
            switch (value)
            {
                case Models.Client:
                    {
                        _client = (Client)value;
                        IsDriver = false;
                        return;
                    }
                case Models.Driver:
                    {
                        _driver = (Driver)value;
                        IsDriver = true;
                        break;
                    }
            }
        }

        #endregion

        #region Constructors

        public ProfileVM(object value)
        {
            Initialization(value);
            _profilePageService = new(this);
        }

        #endregion

        #region Commands

        private Command _backButtonCommand;
        public Command BackButtonCommand
        {
            get => _backButtonCommand ??= new(_profilePageService.BackButtonClicked);
        }

        private Command _goToRequestsCommand;
        public Command GoToRequestsCommand
        {
            get => _goToRequestsCommand ??= new(_profilePageService.GoToRequestsClicked);
        }

        private Command _editAccountCommand;
        public Command EditAccountCommand
        {
            get => _editAccountCommand ??= new(_profilePageService.EditAccountClicked);
        }

        #endregion
    }
}
