using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class EditAccountPageService
    {
        #region Private Fields

        private readonly EditAccountVM _editAccountVM;
        private readonly DataBaseService _dataBaseService;

        #endregion

        #region Constructors

        public EditAccountPageService(EditAccountVM editAccountVM)
        {
            _editAccountVM = editAccountVM;
            _dataBaseService = new();
        }

        #endregion

        #region Public Methods

        public void SaveSettingsClicked()
        {
            if (_editAccountVM.AreFieldsValid())
            {
                if (_editAccountVM.Client != null)
                {
                    _editAccountVM.Client.Password = _editAccountVM.Password.Item1.Value;
                    _editAccountVM.Client.Name = _editAccountVM.Name.Value;

                    ProfilePage profilePage = new(_dataBaseService.UpdateClient(_editAccountVM.Client));
                    Application.Current.MainPage = profilePage;
                    return;
                }
                if (_editAccountVM.Driver != null)
                {
                    _editAccountVM.Driver.Password = _editAccountVM.Password.Item1.Value;
                    _editAccountVM.Driver.Name = _editAccountVM.Name.Value;
                    _editAccountVM.Driver.CarModel = _editAccountVM.CarModel.Value;
                    _editAccountVM.Driver.LicensePlate = _editAccountVM.LicensePlate.Value;

                    ProfilePage profilePage = new(_dataBaseService.UpdateDriver(_editAccountVM.Driver));
                    Application.Current.MainPage = profilePage;
                }
            }
        }

        public void BackButtonClicked()
        {
            if (_editAccountVM.Driver != null)
            {
                ProfilePage profilePage = new(_editAccountVM.Driver);
                Application.Current.MainPage = profilePage;
                return;
            }
            if (_editAccountVM.Client != null)
            {
                ProfilePage profilePage = new(_editAccountVM.Client);
                Application.Current.MainPage = profilePage;
            }
        }

        #endregion
    }
}
