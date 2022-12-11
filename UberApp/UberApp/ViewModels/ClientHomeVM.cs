using System.Collections.ObjectModel;
using UberApp.Models;
using UberApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace UberApp.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ClientHomeVM : BaseVM
    {
        #region Private Fields

        private readonly ClientPageService _clientPageService;
        private readonly Client _client;
        private Pin _pin;
        private string _address;

        #endregion

        #region Public Properties

        public ObservableCollection<Pin> Pins { get; set; }

        #endregion

        #region Properties

        public Pin Pin
        {
            get => _pin;
            set
            {
                _pin = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (value == null)
                {
                    return;
                }
                _address = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public ClientHomeVM(Client client)
        {
            Pins = new();
            _clientPageService = new(this);
            _client = client;


        }

        #endregion

        #region Commands

        private Command _callCabCommand;
        public Command CallCabCommand
        {
            get => _callCabCommand ??= new(_clientPageService.CallCab);
        }

        private Command _goToLocationCommand;
        public Command GoToLocationCommand
        {
            get => _goToLocationCommand ??= new(_clientPageService.GoToLocationCommand);
        }

        private Command _openLoginPageCommand;
        public Command OpenLoginPageCommand
        {
            get => _openLoginPageCommand ??= new(_clientPageService.OpenLoginPageClicked);
        }

        #endregion
    }
}
