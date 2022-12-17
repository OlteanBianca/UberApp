using UberApp.ViewModels;
using UberApp.Views;
using Xamarin.Forms;

namespace UberApp.Services
{
    public class ProfilePageService
    {
        #region Private Fields

        private readonly DataBaseService _dataBaseService;
        private readonly ProfileVM _profilePageVM;

        #endregion

        #region Constructors

        public ProfilePageService(ProfileVM vm)
        {
            _profilePageVM = vm;
            _dataBaseService = new();
        }

        #endregion

        #region Public Methods

        public void BackButtonClicked()
        {
            if (_profilePageVM.Driver != null)
            {
                DriverHomePage driverHomePage = new(_profilePageVM.Driver);
                Application.Current.MainPage = driverHomePage;
                return;
            }
            if (_profilePageVM.Client != null)
            {
                ClientHomePage clientHomePage = new(_profilePageVM.Client);
                Application.Current.MainPage = clientHomePage;
            }
        }

        public void GoToRequestsClicked()
        {
            if (_profilePageVM.Client != null)
            {
                RequestsListPage requestsListPage = new(_profilePageVM.Client);
                Application.Current.MainPage = requestsListPage;
                return;
            }
            if (_profilePageVM.Driver != null)
            {
                RequestsListPage requestsListPage = new(_profilePageVM.Driver);
                Application.Current.MainPage = requestsListPage;
            }
        }

        public void EditAccountClicked()
        {
            if (_profilePageVM.Client != null)
            {
                EditAccountPage editAccountPage = new(_profilePageVM.Client);
                Application.Current.MainPage = editAccountPage;
                return;
            }
            if (_profilePageVM.Driver != null)
            {
                EditAccountPage editAccountPage = new(_profilePageVM.Driver);
                Application.Current.MainPage = editAccountPage;
            }
        }

        #endregion
    }
}
